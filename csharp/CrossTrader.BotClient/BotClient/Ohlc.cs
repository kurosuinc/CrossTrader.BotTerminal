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

            OpenTime = message.OpenTime.ToDateTimeOffset();
            OpenPrice = message.OpenPrice;
            HighPrice = message.HighPrice;
            LowPrice = message.LowPrice;
            ClosePrice = message.ClosePrice;
        }

        public int InstrumentId { get; }

        public TimeSpan TimeFrame { get; }

        public DateTimeOffset CloseTime => OpenTime + TimeFrame;

        public DateTimeOffset OpenTime { get; }
        public double OpenPrice { get; }
        public double HighPrice { get; }
        public double LowPrice { get; }
        public double ClosePrice { get; }

        internal bool IsValid
            => OpenTime > DateTimeOffset.MinValue;
    }
}