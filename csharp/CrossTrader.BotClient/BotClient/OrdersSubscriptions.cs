using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class OrdersSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<Order>>
    {
        public OrdersSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<Order>, bool> callback)
             => Client.SubscribeOrdersAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<Order> response)
            => Client.RaiseOrdersReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.RaiseOrdersError(key, exception);
    }
}
