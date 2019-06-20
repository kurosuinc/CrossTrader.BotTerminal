using System;
using CrossTrader.Models.Remoting.BitFlyer;

namespace CrossTrader.BotClient.BitFlyer
{
    public sealed class BitFlyerPosition
    {
        internal BitFlyerPosition(int instrumentId, PositionMessage message)
        {
            InstrumentId = instrumentId;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
            Commission = message.Commission;
            SwapPointAccumulate = message.SwapPointAccumulate;
            RequireCollateral = message.RequireCollateral;
            OpenDate = message.OpenDate.ToClientValue() ?? default;
            Leverage = message.Leverage;
            Pnl = message.Pnl;
            Sfd = message.Sfd;
        }

        public int InstrumentId { get; }

        public OrderSide Side { get; }
        public double Price { get; }
        public double Size { get; }
        public double Commission { get; }
        public double SwapPointAccumulate { get; }
        public double RequireCollateral { get; }
        public DateTimeOffset OpenDate { get; }
        public double Leverage { get; }
        public double Pnl { get; }
        public double Sfd { get; }

        internal bool IsValid
            => OpenDate > DateTimeOffset.MinValue
            || Size != 0;
    }
}