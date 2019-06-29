using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Ohlc
    {
        internal Ohlc(int instrumentId, TimeSpan timeFrame, OhlcMessage message)
        {
            InstrumentId = instrumentId;
            TimeFrame = timeFrame;

            OpenedAt = message.OpenedAt.ToDateTimeOffset();
            OpenPrice = message.OpenPrice;
            HighPrice = message.HighPrice;
            LowPrice = message.LowPrice;
            ClosePrice = message.ClosePrice;
        }

        public int InstrumentId { get; }

        public TimeSpan TimeFrame { get; }

        public DateTimeOffset OpenedAt { get; }
        public DateTimeOffset ClosedAt => OpenedAt + TimeFrame;

        public double OpenPrice { get; }
        public double HighPrice { get; }
        public double LowPrice { get; }
        public double ClosePrice { get; }

        internal bool IsValid
            => OpenedAt > DateTimeOffset.MinValue;
    }
}