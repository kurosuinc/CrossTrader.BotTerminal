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

        private BitMexTradesSubscriptionCollection _TradesSubscriptions;

        public event EventHandler<CollectionReceivedEventArgs<BitMexTrade>> TradesReceived;

        public event EventHandler<InstrumentIdErrorEventArgs> TradesError;

        internal BitMexTradesSubscriptionCollection TradesSubscriptions
            => _TradesSubscriptions ?? (_TradesSubscriptions = new BitMexTradesSubscriptionCollection(_Client));

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

        public void Dispose()
        {
            _TradesSubscriptions?.Dispose();
            _TradesSubscriptions = null;
            TradesReceived = null;
            TradesError = null;
        }
    }
}