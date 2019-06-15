using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class TickerSubscriptionCollection : SubscriptionCollection<int, Ticker>
    {
        public TickerSubscriptionCollection(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, Ticker, bool> callback)
             => Client.SubscribeTickerAsync(key, callback);

        protected override void Notify(int key, Ticker response)
            => Client.RaiseTickerReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.RaiseTickerError(key, exception);
    }
}