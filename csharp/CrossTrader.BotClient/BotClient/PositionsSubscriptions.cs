using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class PositionsSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<Position>>
    {
        public PositionsSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<Position>, bool> callback)
             => Client.SubscribePositionsAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<Position> response)
            => Client.RaisePositionsReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.RaisePositionsError(key, exception);
    }
}
