using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Position : IEquatable<Position>
    {
        internal Position(int instrumentId, PositionMessage message)
        {
            InstrumentId = instrumentId;
            Side = message.Side.ToClientValue();
            Price = message.Price;
            Size = message.Size;
            OpenedAt = message.OpenedAt.ToClientValue();
            Id = message.Id;
        }

        #region Properties

        public int InstrumentId { get; }

        public OrderSide Side { get; set; }

        public double? Price { get; set; }

        public double Size { get; set; }

        public DateTimeOffset? OpenedAt { get; set; }

        public string Id { get; set; }

        #endregion

        public bool IsValid =>
            !(Side == OrderSide.None ||
              Size == 0 ||
              Price == 0);

        bool IEquatable<Position>.Equals(Position other)
            => Id.Equals(other.Id);

        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
