using System;
using CrossTrader.Models.Remoting.BitMex;

namespace CrossTrader.BotClient.BitMex
{
    public sealed class BitMexPosition
    {
        internal BitMexPosition(int instrumentId, PositionMessage message)
        {
            InstrumentId = instrumentId;

            Leverage = message.Leverage;
            CrossMargin = message.CrossMargin;
            OpeningTimestamp = message.OpeningTimestamp.ToClientValue() ?? default;
            OpenOrderBuyQuantity = message.OpenOrderBuyQuantity;
            OpenOrderSellQuantity = message.OpenOrderSellQuantity;
            CurrentQuantity = message.CurrentQuantity;
            CurrentCost = message.CurrentCost;
            CurrentCommision = message.CurrentCommision;
            UnrealizedProfit = message.UnrealizedProfit;
            UnrealizedProfitPercent = message.UnrealizedProfitPercent;
            UnrealizedRoePercent = message.UnrealizedRoePercent;
            AverageEntryPrice = message.AverageEntryPrice;
            Timestamp = message.Timestamp.ToClientValue() ?? default;
        }

        public int InstrumentId { get; }

        public double Leverage { get; }
        public bool CrossMargin { get; }
        public DateTimeOffset OpeningTimestamp { get; }
        public double OpenOrderBuyQuantity { get; }
        public double OpenOrderSellQuantity { get; }
        public double CurrentQuantity { get; }
        public double CurrentCost { get; }
        public double CurrentCommision { get; }
        public double UnrealizedProfit { get; }
        public double UnrealizedProfitPercent { get; }
        public double UnrealizedRoePercent { get; }
        public double AverageEntryPrice { get; }
        public DateTimeOffset Timestamp { get; }

        internal bool IsValid
            => Timestamp != default
            || CurrentQuantity != 0;
    }
}