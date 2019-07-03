using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitMex
{
    internal sealed class BitMexOrdersSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<BitMexOrder>>
    {
        public BitMexOrdersSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitMexOrder>, bool> callback)
             => Client.BitMex.SubscribeOrdersAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitMexOrder> response)
            => Client.BitMex.RaiseOrdersReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitMex.RaiseOrdersError(key, exception);
    }
}