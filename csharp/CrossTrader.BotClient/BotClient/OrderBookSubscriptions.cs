using System;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class OrderBookSubscriptions : Subscriptions<Tuple<int, double, int>, OrderBook>
    {
        public OrderBookSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(Tuple<int, double, int> key, Func<Tuple<int, double, int>, OrderBook, bool> callback)
            => Client.SubscribeOrderBookAsync(
                key.Item1,
                key.Item2,
                key.Item3,
                r => callback(Tuple.Create(r.InstrumentId, r.GroupSize, r.LevelCount), r));

        protected override void Notify(Tuple<int, double, int> key, OrderBook response)
            => Client.RaiseOrderBookReceived(response);

        protected override void OnError(Tuple<int, double, int> key, Exception exception)
            => Client.RaiseOrderBookError(key.Item1, key.Item2, key.Item3, exception);
    }
}