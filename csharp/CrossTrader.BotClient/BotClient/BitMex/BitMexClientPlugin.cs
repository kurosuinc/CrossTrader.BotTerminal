using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossTrader.Models.Remoting.BitMex;

namespace CrossTrader.BotClient.BitMex
{
    public sealed class BitMexClientPlugin : IDisposable
    {
        private readonly CrossTraderClient _Client;

        internal BitMexClientPlugin(CrossTraderClient client)
        {
            _Client = client;
        }

        #region TradesService

        private BitMexTradesSubscriptions _TradesSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<BitMexTrade>> TradesReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> TradesError;

        internal BitMexTradesSubscriptions TradesSubscriptions
            => _TradesSubscriptions ?? (_TradesSubscriptions = new BitMexTradesSubscriptions(_Client));

        [Rpc(nameof(TradesService))]
        public async Task SubscribeTradesAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<BitMexTrade>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await _Client.OpenAsync().ConfigureAwait(false))
            using (var res = new TradesService.TradesServiceClient(_Client.Channel).SubscribeTrades(
                                    new Models.Remoting.InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<BitMexTrade>(
                        c.Action,
                        c.Trades.Select(e => new BitMexTrade(instrumentId, e)).Where(e => e.IsValid));

                    if (callback?.Invoke(instrumentId, m) != true)
                    {
                        return;
                    }
                }
            }
        }

        public void SubscribeTrades(int instrumentId)
            => TradesSubscriptions.Subscribe(instrumentId);

        public void UnsubscribeTrades(int instrumentId)
            => TradesSubscriptions.Unsubscribe(instrumentId);

        internal void RaiseTradesReceived(CollectionReceivedEventArgs<BitMexTrade> e)
        {
            if (e?.Data?.Count > 0)
            {
                TradesReceived?.Invoke(this, e);
            }
        }

        internal void RaiseTradesError(int instrumentId, Exception exception)
            => TradesError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion TradesService

        #region OrdersService

        private BitMexOrdersSubscriptions _OrdersSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<BitMexOrder>> OrdersReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> OrdersError;

        internal BitMexOrdersSubscriptions OrdersSubscriptions
            => _OrdersSubscriptions ?? (_OrdersSubscriptions = new BitMexOrdersSubscriptions(_Client));

        [Rpc(nameof(OrdersService))]
        public async Task SubscribeOrdersAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<BitMexOrder>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await _Client.OpenAsync().ConfigureAwait(false))
            using (var res = new OrdersService.OrdersServiceClient(_Client.Channel).SubscribeOrders(
                                    new Models.Remoting.InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<BitMexOrder>(
                        c.Action,
                        c.Orders.Select(e => new BitMexOrder(instrumentId, e)).Where(e => e.IsValid));

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

        internal void RaiseOrdersReceived(CollectionReceivedEventArgs<BitMexOrder> e)
        {
            if (e?.Data?.Count > 0)
            {
                OrdersReceived?.Invoke(this, e);
            }
        }

        internal void RaiseOrdersError(int instrumentId, Exception exception)
            => OrdersError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion OrdersService

        #region PositionsService

        private BitMexPositionsSubscriptions _PositionsSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<BitMexPosition>> PositionsReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> PositionsError;

        internal BitMexPositionsSubscriptions PositionsSubscriptions
            => _PositionsSubscriptions ?? (_PositionsSubscriptions = new BitMexPositionsSubscriptions(_Client));

        [Rpc(nameof(PositionsService))]
        public async Task SubscribePositionsAsync(int instrumentId, Func<int, CollectionReceivedEventArgs<BitMexPosition>, bool> callback, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            using (await _Client.OpenAsync().ConfigureAwait(false))
            using (var res = new PositionsService.PositionsServiceClient(_Client.Channel).SubscribePositions(
                                    new Models.Remoting.InstrumentIdRequest() { InstrumentId = instrumentId },
                                    deadline: deadline,
                                    cancellationToken: cancellationToken))
            {
                while (await res.ResponseStream.MoveNext(cancellationToken).ConfigureAwait(false)
                        && !cancellationToken.IsCancellationRequested)
                {
                    var c = res.ResponseStream.Current;
                    var m = new CollectionReceivedEventArgs<BitMexPosition>(
                        c.Action,
                        c.Positions.Select(e => new BitMexPosition(instrumentId, e)).Where(e => e.IsValid));

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

        internal void RaisePositionsReceived(CollectionReceivedEventArgs<BitMexPosition> e)
        {
            if (e?.Data?.Count > 0)
            {
                PositionsReceived?.Invoke(this, e);
            }
        }

        internal void RaisePositionsError(int instrumentId, Exception exception)
            => PositionsError?.Invoke(this, new InstrumentIdErrorEventArgs(instrumentId, exception));

        #endregion PositionsService

        public void Dispose()
        {
            _TradesSubscriptions?.Dispose();
            _TradesSubscriptions = null;
            TradesReceived = null;
            TradesError = null;

            _OrdersSubscriptions?.Dispose();
            _OrdersSubscriptions = null;
            OrdersReceived = null;
            OrdersError = null;

            _PositionsSubscriptions?.Dispose();
            _PositionsSubscriptions = null;
            PositionsReceived = null;
            PositionsError = null;
        }
    }
}