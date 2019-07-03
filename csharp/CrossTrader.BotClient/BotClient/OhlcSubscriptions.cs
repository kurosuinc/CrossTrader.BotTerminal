using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrossTrader.BotClient
{
    internal sealed class OhlcSubscriptions : Subscriptions<Tuple<int, TimeSpan>, CollectionReceivedEventArgs<Ohlc>>
    {
        public OhlcSubscriptions(CrossTraderClient client)
            : base(client)
        {
        }

        protected override Task SubscribeAsync(Tuple<int, TimeSpan> key, Func<Tuple<int, TimeSpan>, CollectionReceivedEventArgs<Ohlc>, bool> callback)
            => Client.SubscribeOhlcAsync(
                key.Item1,
                key.Item2,
                r =>
                {
                    var f = r.Data.FirstOrDefault();
                    return callback(
                        Tuple.Create(f?.InstrumentId ?? 0, f?.TimeFrame ?? default),
                        r);
                });

        protected override void Notify(Tuple<int, TimeSpan> key, CollectionReceivedEventArgs<Ohlc> response)
            => Client.RaiseOhlcReceived(response);

        protected override void OnError(Tuple<int, TimeSpan> key, Exception exception)
            => Client.RaiseOhlcError(key.Item1, key.Item2, exception);
    }
}