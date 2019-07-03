using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitFlyer
{
    internal sealed class BitFlyerPositionsSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<BitFlyerPosition>>
    {
        public BitFlyerPositionsSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitFlyerPosition>, bool> callback)
             => Client.BitFlyer.SubscribePositionsAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitFlyerPosition> response)
            => Client.BitFlyer.RaisePositionsReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitFlyer.RaisePositionsError(key, exception);
    }
}