using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitFlyer
{
    internal sealed class BitFlyerChildOrdersSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<BitFlyerChildOrder>>
    {
        public BitFlyerChildOrdersSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitFlyerChildOrder>, bool> callback)
             => Client.BitFlyer.SubscribeChildOrdersAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitFlyerChildOrder> response)
            => Client.BitFlyer.RaiseChildOrdersReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitFlyer.RaiseChildOrdersError(key, exception);
    }
}