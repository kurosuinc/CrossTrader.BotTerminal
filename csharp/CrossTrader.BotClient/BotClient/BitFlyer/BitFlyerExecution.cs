using System;
using CrossTrader.Models.Remoting.BitFlyer;

namespace CrossTrader.BotClient.BitFlyer
{
    public sealed class BitFlyerExecution
    {
        internal BitFlyerExecution(int instrumentId, ExecutionMessage message)
        {
            InstrumentId = instrumentId;

            Id = message.Id;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
            ExecutedAt = message.ExecutedAt.ToClientValue() ?? default;

            BuyChildOrderAcceptanceId = message.BuyChildOrderAcceptanceId.EmptyToNull();
            SellChildOrderAcceptanceId = message.SellChildOrderAcceptanceId.EmptyToNull();
        }

        public int InstrumentId { get; }

        public long Id { get; }
        public OrderSide Side { get; }
        public double Price { get; }
        public double Size { get; }

        public DateTimeOffset ExecutedAt { get; }

        public string BuyChildOrderAcceptanceId { get; }
        public string SellChildOrderAcceptanceId { get; }

        internal bool IsValid
            => ExecutedAt > DateTimeOffset.MinValue
            && Side != OrderSide.None
            && Price > 0
            && Size >= 0;
    }
}