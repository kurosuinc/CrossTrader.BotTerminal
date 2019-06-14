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

        public async Task<Exchange[]> GetExchangesAsync(CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new ExchangeService.ExchangeServiceClient(Channel).GetExchangesAsync(new Empty(), cancellationToken: cancellationToken);
                var items = new Exchange[res.Exchanges.Count];
                for (var i = 0; i < items.Length; i++)
                {
                    items[i] = new Exchange(res.Exchanges[i]);
                }
                return items;
            }
        }

        public async Task<Exchange> GetExchangeAsync(string name, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new ExchangeService.ExchangeServiceClient(Channel).GetExchangeAsync(new NameRequest() { Name = name }, cancellationToken: cancellationToken);
                if (res.Exchange != null)
                {
                    return new Exchange(res.Exchange, res.Instruments);
                }
                return null;
            }
        }

        #endregion ExchangeService

        #region IDisposable Support

        protected bool IsDisposed { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
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