using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class ExecutionsSubscriptionCollection : SubscriptionCollection<int, CollectionReceivedEventArgs<Execution>>
    {
        public ExecutionsSubscriptionCollection(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<Execution>, bool> callback)
             => Client.SubscribeExecutionsAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<Execution> response)
            => Client.RaiseExecutionsReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.RaiseExecutionsError(key, exception);
    }
}