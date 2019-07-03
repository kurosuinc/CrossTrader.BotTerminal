using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitMex
{
    internal sealed class BitMexTradesSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<BitMexTrade>>
    {
        public BitMexTradesSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitMexTrade>, bool> callback)
             => Client.BitMex.SubscribeTradesAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitMexTrade> response)
            => Client.BitMex.RaiseTradesReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitMex.RaiseTradesError(key, exception);
    }
}