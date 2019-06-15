using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitFlyer
{
    internal sealed class BitFlyerExecutionsSubscriptionCollection : SubscriptionCollection<int, CollectionReceivedEventArgs<BitFlyerExecution>>
    {
        public BitFlyerExecutionsSubscriptionCollection(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitFlyerExecution>, bool> callback)
             => Client.BitFlyer.SubscribeExecutionsAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitFlyerExecution> response)
            => Client.BitFlyer.RaiseExecutionsReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitFlyer.RaiseExecutionsError(key, exception);
    }
}