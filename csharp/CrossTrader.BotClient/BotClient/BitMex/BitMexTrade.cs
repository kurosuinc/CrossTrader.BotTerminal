using System;
using CrossTrader.Models.Remoting.BitMex;

namespace CrossTrader.BotClient.BitMex
{
    public sealed class BitMexTrade
    {
        internal BitMexTrade(int instrumentId, TradeMessage message)
        {
            InstrumentId = instrumentId;

            Timestamp = message.Timestamp.ToClientValue() ?? default;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
            TickDirection = message.TickDirection.ToClientValue();
            TradeMatchId = Guid.TryParse(message.TradeMatchId, out var id) ? id : default;
            GrossValue = message.GrossValue;
            HomeNotional = message.HomeNotional;
            ForeignNotional = message.ForeignNotional;
        }

        public int InstrumentId { get; }

        public DateTimeOffset Timestamp { get; }
        public OrderSide Side { get; }
        public double Size { get; }
        public double Price { get; }
        public BitMexTickDirection TickDirection { get; }
        public Guid TradeMatchId { get; }
        public double GrossValue { get; }
        public double HomeNotional { get; }
        public double ForeignNotional { get; }

        internal bool IsValid
            => Timestamp > DateTimeOffset.MinValue
            && Side != OrderSide.None
            && Price > 0
            && Size >= 0;
    }
}