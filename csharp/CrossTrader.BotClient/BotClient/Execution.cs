using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Execution
    {
        internal Execution(int instrumentId, ExecutionMessage message)
        {
            InstrumentId = instrumentId;

            CreatedAt = message.CreatedAt.ToClientValue() ?? default;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
        }

        public int InstrumentId { get; }

        public DateTimeOffset CreatedAt { get; }
        public OrderSide Side { get; }
        public double Price { get; }
        public double Size { get; }

        internal bool IsValid
            => CreatedAt > DateTimeOffset.MinValue
            && Side != OrderSide.None
            && Price > 0
            && Size >= 0;
    }
}