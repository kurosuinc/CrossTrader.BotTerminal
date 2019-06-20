using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient.BitMex
{
    internal sealed class BitMexPositionsSubscriptions : Subscriptions<int, CollectionReceivedEventArgs<BitMexPosition>>
    {
        public BitMexPositionsSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(int key, Func<int, CollectionReceivedEventArgs<BitMexPosition>, bool> callback)
             => Client.BitMex.SubscribePositionsAsync(key, callback);

        protected override void Notify(int key, CollectionReceivedEventArgs<BitMexPosition> response)
            => Client.BitMex.RaisePositionsReceived(response);

        protected override void OnError(int key, Exception exception)
            => Client.BitMex.RaisePositionsError(key, exception);
    }
}