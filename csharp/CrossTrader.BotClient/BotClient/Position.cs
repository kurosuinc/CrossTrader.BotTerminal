using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Position
    {
        internal Position(int instrumentId, PositionMessage message)
        {
            InstrumentId = instrumentId;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
            OpenedAt = message.OpenedAt.ToClientValue();
        }

        #region Properties

        public int InstrumentId { get; }

        public OrderSide Side { get; set; }

        public double? Price { get; set; }

        public double Size { get; set; }

        public DateTimeOffset? OpenedAt { get; set; }

        #endregion

        public bool IsValid =>
            !(Side == OrderSide.None ||
              Price == 0);
    }
}
