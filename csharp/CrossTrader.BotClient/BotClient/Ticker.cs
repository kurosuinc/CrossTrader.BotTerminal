using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Ticker
    {
        internal Ticker(int instrumentId, TickerMessage message)
        {
            InstrumentId = instrumentId;
            BestAsk = message.BestAsk.PositiveOrNull();
            BestBid = message.BestBid.PositiveOrNull();
        }

        public int InstrumentId { get; }

        public double? BestAsk { get; }
        public double? BestBid { get; }

        public bool IsValid
            => BestAsk > 0 && BestBid > 0;
    }
}