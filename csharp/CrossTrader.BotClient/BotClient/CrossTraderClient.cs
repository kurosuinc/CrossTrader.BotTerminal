using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CrossTrader.BotClient.BitFlyer;
using CrossTrader.BotClient.BitMex;
using CrossTrader.Models.Remoting;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CrossTrader.BotClient
{
    public class CrossTraderClient : IDisposable
    {
        protected internal struct ChannelSubscription : IEquatable<ChannelSubscription>, IDisposable
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

        protected internal Channel Channel
            => _ChannelTask?.Status == TaskStatus.RanToCompletion ? _ChannelTask.Result : null;

        protected internal Task<ChannelSubscription> OpenAsync()
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

        private TickerSubscriptions _TickerSubscriptions;

        public event EventHandler<ReceivedEventArgs<Ticker>> TickerReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> TickerError;

        internal TickerSubscriptions TickerSubscriptions
            => _TickerSubscriptions ?? (_TickerSubscriptions = new TickerSubscriptions(this));

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

        private ExecutionsSubscriptions _ExecutionsSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<Execution>> ExecutionsReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> ExecutionsError;

        internal ExecutionsSubscriptions ExecutionsSubscriptions
            => _ExecutionsSubscriptions ?? (_ExecutionsSubscriptions = new ExecutionsSubscriptions(this));

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
            if (e.Action == NotifyCollectionChangedAction.Reset || e?.Data?.Count > 0)
            {
                ExecutionsReceived?.Invoke(this, e);
            }
        }

        protected internal void RaiseExecutionsError(int instrumentId, Exception exception)
            => ExecutionsError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion ExecutionsService

        #region OrdersService

        private OrdersSubscriptions _OrdersSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<Order>> OrdersReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> OrdersError;

        internal OrdersSubscriptions OrdersSubscriptions
            => _OrdersSubscriptions ?? (_OrdersSubscriptions = new OrdersSubscriptions(this));

        [Rpc(nameof(OrdersService))]
        public async Task SubscribeOrdersAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<Order>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new OrdersService.OrdersServiceClient(Channel).SubscribeOrders(
                                    new InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<Order>(
                        c.Action,
                        c.Orders.Select(e => new Order(instrumentId, e)).Where(e => e.IsValid));

                    if (callback?.Invoke(instrumentId, m) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeOrders(int instrumentId)
            => OrdersSubscriptions.Subscribe(instrumentId);

        public void UnsubscribeOrders(int instrumentId)
            => OrdersSubscriptions.Unsubscribe(instrumentId);

        protected internal void RaiseOrdersReceived(CollectionReceivedEventArgs<Order> e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset || e?.Data?.Count > 0)
            {
                OrdersReceived?.Invoke(this, e);
            }
        }

        protected internal void RaiseOrdersError(int instrumentId, Exception exception)
            => OrdersError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        [Rpc(nameof(OrdersService))]
        public async Task<Order> PostOrderAsync(int instrumentId, OrderType type, OrderSide side, double size, double? price, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new OrdersService.OrdersServiceClient(Channel).PostOrderAsync(
                    new PostOrderRequest()
                    {
                        InstrumentId = instrumentId,
                        Side = side.ToMessage(),
                        Type = type.ToMessage(),
                        Size = size,
                        Price = price ?? 0.0
                    },
                    deadline: deadline,
                    cancellationToken: cancellationToken);
                var t = res != null ? new Order(instrumentId, res) : null;
                return t?.IsValid == true ? t : null;
            }
        }

        [Rpc(nameof(OrdersService))]
        public async Task<bool> CancelOrderAsync(int instrumentId, string OrderId, string RequestId, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new OrdersService.OrdersServiceClient(Channel).CancelOrderAsync(
                    new OrderCancellationRequest()
                    {
                        InstrumentId = instrumentId,
                        OrderId = OrderId,
                        RequestId = RequestId
                    },
                    deadline: deadline,
                    cancellationToken: cancellationToken);
                return res?.Canceled ?? false;
            }
        }

        [Rpc(nameof(OrdersService))]
        public async Task<bool> CancelAllOrdersAsync(int instrumentId, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            {
                var res = await new OrdersService.OrdersServiceClient(Channel).CancelAllOrdersAsync(
                    new EntireOrderCancellationRequest()
                    {
                        InstrumentId = instrumentId
                    },
                    deadline: deadline,
                    cancellationToken: cancellationToken);
                return res?.Canceled ?? false;
            }
        }

        #endregion

        #region PositionsService

        private PositionsSubscriptions _PositionsSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<Position>> PositionsReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> PositionsError;

        internal PositionsSubscriptions PositionsSubscriptions
            => _PositionsSubscriptions ?? (_PositionsSubscriptions = new PositionsSubscriptions(this));

        [Rpc(nameof(PositionsService))]
        public async Task SubscribePositionsAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<Position>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new PositionsService.PositionsServiceClient(Channel).SubscribePositions(
                                    new InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<Position>(
                        c.Action,
                        c.Positions.Select(e => new Position(instrumentId, e)).Where(e => e.IsValid));

                    if (callback?.Invoke(instrumentId, m) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribePositions(int instrumentId)
            => PositionsSubscriptions.Subscribe(instrumentId);

        public void UnsubscribePositions(int instrumentId)
            => PositionsSubscriptions.Unsubscribe(instrumentId);

        protected internal void RaisePositionsReceived(CollectionReceivedEventArgs<Position> e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset || e?.Data?.Count > 0)
            {
                PositionsReceived?.Invoke(this, e);
            }
        }

        protected internal void RaisePositionsError(int instrumentId, Exception exception)
            => PositionsError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion

        #region OrderBookService

        #region SubscribeOrderBookAsync

        private OrderBookSubscriptions _OrderBookSubscriptions;

        public event EventHandler<ReceivedEventArgs<OrderBook>> OrderBookReceived;

        public event EventHandler<OrderBookErrorEventArgs> OrderBookError;

        internal OrderBookSubscriptions OrderBookSubscriptions
            => _OrderBookSubscriptions ?? (_OrderBookSubscriptions = new OrderBookSubscriptions(this));

        [Rpc(nameof(OrderBookService))]
        public async Task SubscribeOrderBookAsync(int instrumentId, double groupSize, int levelCount, Func<OrderBook, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new OrderBookService.OrderBookServiceClient(Channel).SubscribeOrderBook(
                                    new OrderBookRequest()
                                    {
                                        InstrumentId = instrumentId,
                                        GroupSize = groupSize,
                                        LevelCount = levelCount
                                    },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var t = new OrderBook(instrumentId, groupSize, levelCount, res.ResponseStream.Current);
                    if (callback?.Invoke(t) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeOrderBook(int instrumentId, double groupSize, int levelCount)
            => OrderBookSubscriptions.Subscribe(Tuple.Create(instrumentId, groupSize, levelCount));

        public void UnsubscribeOrderBook(int instrumentId, double groupSize, int levelCount)
            => OrderBookSubscriptions.Unsubscribe(Tuple.Create(instrumentId, groupSize, levelCount));

        protected internal void RaiseOrderBookReceived(OrderBook OrderBook)
        {
            if (OrderBook?.IsValid == true)
            {
                OrderBookReceived?.Invoke(this, new ReceivedEventArgs<OrderBook>(OrderBook));
            }
        }

        protected internal void RaiseOrderBookError(int instrumentId, double groupSize, int levelCount, Exception exception)
            => OrderBookError?.Invoke(this, new OrderBookErrorEventArgs(instrumentId, groupSize, levelCount, exception));

        #endregion

        #endregion OrderBookService

        #region ChartService

        #region SubscribeOhlcAsync

        private OhlcSubscriptions _OhlcSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<Ohlc>> OhlcReceived;

        public event EventHandler<TimeFrameErrorEventArgs> OhlcError;

        internal OhlcSubscriptions OhlcSubscriptions
            => _OhlcSubscriptions ?? (_OhlcSubscriptions = new OhlcSubscriptions(this));

        [Rpc(nameof(ChartService))]
        public async Task SubscribeOhlcAsync(int instrumentId, TimeSpan timeFrame, Func<CollectionReceivedEventArgs<Ohlc>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await OpenAsync().ConfigureAwait(false))
            using (var res = new ChartService.ChartServiceClient(Channel).SubscribeOhlc(
                                    new TimeFrameRequest()
                                    {
                                        InstrumentId = instrumentId,
                                        TimeFrame = timeFrame.ToDuration()
                                    },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var t = new CollectionReceivedEventArgs<Ohlc>(c.Action, c.Items.Select(e => new Ohlc(instrumentId, timeFrame, e)).Where(e => e.IsValid));
                    if (callback?.Invoke(t) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeOhlc(int instrumentId, TimeSpan timeFrame)
            => OhlcSubscriptions.Subscribe(Tuple.Create(instrumentId, timeFrame));

        public void UnsubscribeOhlc(int instrumentId, TimeSpan timeFrame)
            => OhlcSubscriptions.Unsubscribe(Tuple.Create(instrumentId, timeFrame));

        protected internal void RaiseOhlcReceived(CollectionReceivedEventArgs<Ohlc> e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset || e?.Data?.Count > 0)
            {
                OhlcReceived?.Invoke(this, e);
            }
        }

        protected internal void RaiseOhlcError(int instrumentId, TimeSpan timeFrame, Exception exception)
            => OhlcError?.Invoke(this, new TimeFrameErrorEventArgs(instrumentId, timeFrame, exception));

        #endregion

        #endregion OhlcService

        #region BitFlyer

        private BitFlyerClientPlugin _BitFlyer;

        public BitFlyerClientPlugin BitFlyer
            => _BitFlyer ?? (_BitFlyer = new BitFlyerClientPlugin(this));

        #endregion BitFlyer

        #region BitMex

        private BitMexClientPlugin _BitMex;

        public BitMexClientPlugin BitMex
            => _BitMex ?? (_BitMex = new BitMexClientPlugin(this));

        #endregion BitMex

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

                    _ExecutionsSubscriptions?.Dispose();
                    _ExecutionsSubscriptions = null;
                    ExecutionsReceived = null;
                    ExecutionsError = null;

                    _BitFlyer?.Dispose();
                    _BitFlyer = null;

                    _BitMex?.Dispose();
                    _BitMex = null;

                    lock (_Subscriptions)
                    {
                        _Subscriptions.Clear();
                        DisposeChannel();
                    }
                }

                IsDisposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        #endregion IDisposable Support
    }
}