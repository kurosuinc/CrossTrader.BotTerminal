using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CrossTrader.Models.Remoting;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CrossTrader.BotClient
{
    public class CrossTraderClient : IDisposable
    {
        protected struct ChannelSubscription : IEquatable<ChannelSubscription>, IDisposable
        {
            internal ChannelSubscription(CrossTraderClient client, int id)
            {
                Client = client;
                Id = id;
            }

            public CrossTraderClient Client { get; }
            public int Id { get; }

            public override bool Equals(object obj)
                => obj is ChannelSubscription s && Equals(s);

            public bool Equals(ChannelSubscription other)
                => Id == other.Id;

            public override int GetHashCode()
                => Id;

            public void Dispose()
                => Client.Close(this);
        }

        #region Connection

        #region Host

        private string _Host;

        public string Host
        {
            get => _Host;
            set
            {
                if (value != _Host)
                {
                    ThrowIfConnected();
                    _Host = value;
                }
            }
        }

        #endregion Host

        #region Port

        private ushort _Port;

        public ushort Port
        {
            get => _Port;
            set
            {
                if (value != _Port)
                {
                    ThrowIfConnected();
                    _Port = value;
                }
            }
        }

        #endregion Port

        #region Channel

        private Task<Channel> _ChannelTask;
        private int _SubscriptionId;
        private readonly List<ChannelSubscription> _Subscriptions = new List<ChannelSubscription>();

        protected Channel Channel
            => _ChannelTask?.Status == TaskStatus.RanToCompletion ? _ChannelTask.Result : null;

        protected Task<ChannelSubscription> OpenAsync()
        {
            lock (_Subscriptions)
            {
                var s = new ChannelSubscription(this, ++_SubscriptionId);
                _Subscriptions.Add(s);

                if (_ChannelTask == null || _ChannelTask.IsFaulted || _ChannelTask.IsCanceled)
                {
                    var c = new Channel(_Host + ":" + _Port, ChannelCredentials.Insecure);
                    _ChannelTask = c.ConnectAsync().ContinueWith(t =>
                    {
                        if (t.Exception != null)
                        {
                            throw new TargetInvocationException(t.Exception);
                        }
                        return c;
                    });
                }

                return _ChannelTask.ContinueWith(t =>
                {
                    t.Result.GetHashCode();
                    return s;
                });
            }
        }

        private void Close(ChannelSubscription s)
        {
            lock (_Subscriptions)
            {
                if (_Subscriptions.Remove(s)
                    && !_Subscriptions.Any()
                    && _ChannelTask != null)
                {
                    DisposeChannel();
                }
            }
        }

        private void DisposeChannel()
        {
            _ChannelTask?.ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    t.Result.ShutdownAsync();
                }
            });
            _ChannelTask = null;
        }

        private void ThrowIfConnected()
        {
            lock (_Subscriptions)
            {
                if (_Subscriptions.Any())
                {
                    throw new InvalidOperationException("Channel is open.");
                }
            }
        }

        #endregion Channel

        #endregion Connection

        #region ExchangeService

        [Rpc(nameof(ExchangeService))]
        public async Task<Exchange[]> GetExchangesAsync(DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new ExchangeService.ExchangeServiceClient(Channel).GetExchangesAsync(
                    new Empty(),
                    deadline: deadline,
                    cancellationToken: cancellationToken);

                var items = new Exchange[res.Exchanges.Count];
                for (var i = 0; i < items.Length; i++)
                {
                    items[i] = new Exchange(res.Exchanges[i]);
                }
                return items;
            }
        }

        [Rpc(nameof(ExchangeService))]
        public async Task<Exchange> GetExchangeAsync(string name, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new ExchangeService.ExchangeServiceClient(Channel).GetExchangeAsync(
                    new NameRequest() { Name = name },
                    deadline: deadline,
                    cancellationToken: cancellationToken);

                if (res.Exchange != null)
                {
                    return new Exchange(res.Exchange, res.Instruments);
                }

                return null;
            }
        }

        #endregion ExchangeService

        #region InstrumentService

        [Rpc(nameof(InstrumentService))]
        public async Task<Instrument[]> GetInstrumentsAsync(DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new InstrumentService.InstrumentServiceClient(Channel).GetInstrumentsAsync(
                    new Empty(),
                    deadline: deadline,
                    cancellationToken: cancellationToken);

                var exchanges = res.Exchanges.Select(e => new Exchange(e)).ToDictionary(e => e.Id);

                var items = new Instrument[res.Instruments.Count];
                for (var i = 0; i < items.Length; i++)
                {
                    var m = res.Instruments[i];
                    exchanges.TryGetValue(m.ExchangeId, out var ex);
                    items[i] = new Instrument(m, ex);
                }
                return items;
            }
        }

        [Rpc(nameof(InstrumentService))]
        public async Task<Instrument> GetInstrumentAsync(string name, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new InstrumentService.InstrumentServiceClient(Channel).GetInstrumentAsync(
                    new NameRequest() { Name = name },
                    deadline: deadline,
                    cancellationToken: cancellationToken);

                if (res.Instrument != null)
                {
                    return new Instrument(res.Instrument, new Exchange(res.Exchange));
                }

                return null;
            }
        }

        #endregion InstrumentService

        #region TickerService

        private TickerSubscriptionCollection _TickerSubscriptions;

        public event EventHandler<ReceivedEventArgs<Ticker>> TickerReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> TickerError;

        internal TickerSubscriptionCollection TickerSubscriptions
            => _TickerSubscriptions ?? (_TickerSubscriptions = new TickerSubscriptionCollection(this));

        [Rpc(nameof(TickerService))]
        public async Task<Ticker> GetTickerAsync(int instrumentId, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new TickerService.TickerServiceClient(Channel).GetTickerAsync(
                    new InstrumentIdRequest() { InstrumentId = instrumentId },
                    deadline: deadline,
                    cancellationToken: cancellationToken);

                var t = res != null ? new Ticker(instrumentId, res) : null;
                return t?.IsValid == true ? t : null;
            }
        }

        [Rpc(nameof(TickerService))]
        public async Task SubscribeTickerAsync(int instrumentId, Func<int, Ticker, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new TickerService.TickerServiceClient(Channel).SubscribeTicker(
                                    new InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var t = new Ticker(instrumentId, res.ResponseStream.Current);
                    if (callback?.Invoke(instrumentId, t) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeTicker(int instrumentId)
            => TickerSubscriptions.Subscribe(instrumentId);

        public void UnsubscribeTicker(int instrumentId)
            => TickerSubscriptions.Unsubscribe(instrumentId);

        protected internal void RaiseTickerReceived(Ticker ticker)
        {
            if (ticker?.IsValid == true)
            {
                TickerReceived?.Invoke(this, new ReceivedEventArgs<Ticker>(ticker));
            }
        }

        protected internal void RaiseTickerError(int instrumentId, Exception exception)
            => TickerError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion TickerService

        #region ExecutionsService

        private ExecutionsSubscriptionCollection _ExecutionsSubscriptions;

        public event EventHandler<ReceivedEventArgs<CollectionReceivedEventArgs<Execution>>> ExecutionsReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> ExecutionsError;

        internal ExecutionsSubscriptionCollection ExecutionsSubscriptions
            => _ExecutionsSubscriptions ?? (_ExecutionsSubscriptions = new ExecutionsSubscriptionCollection(this));

        [Rpc(nameof(ExecutionsService))]
        public async Task SubscribeExecutionsAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<Execution>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new ExecutionsService.ExecutionsServiceClient(Channel).SubscribeExecutions(
                                    new InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<Execution>(
                        c.Action,
                        c.Executions.Select(e => new Execution(instrumentId, e)).Where(e => e.IsValid));

                    if (callback?.Invoke(instrumentId, m) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeExecutions(int instrumentId)
            => ExecutionsSubscriptions.Subscribe(instrumentId);

        public void UnsubscribeExecutions(int instrumentId)
            => ExecutionsSubscriptions.Unsubscribe(instrumentId);

        protected internal void RaiseExecutionsReceived(CollectionReceivedEventArgs<Execution> e)
        {
            if (e?.Data?.Count > 0)
            {
                ExecutionsReceived?.Invoke(this, new ReceivedEventArgs<CollectionReceivedEventArgs<Execution>>(e));
            }
        }

        protected internal void RaiseExecutionsError(int instrumentId, Exception exception)
            => ExecutionsError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion ExecutionsService

        #region IDisposable Support

        protected bool IsDisposed { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _TickerSubscriptions?.Dispose();
                    _TickerSubscriptions = null;
                    TickerReceived = null;
                    TickerError = null;

                    lock (_Subscriptions)
                    {
                        _Subscriptions.Clear();
                        DisposeChannel();
                    }
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}