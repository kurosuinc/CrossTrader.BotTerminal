using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Order
    {
        internal Order(int instrumentId, OrderMessage message)
        {
            InstrumentId = instrumentId;
            Id = message.Id;
            RequestId = message.RequestId;
            Side = message.Side.ToClientValue();
            Type = message.Type.ToClientValue();
            Size = message.Size;
            OutstandingSize = message.OutstandingSize;
            Price = message.Price;
            AveragePrice = message.AveragePrice;
            State = message.State.ToClientValue();
            OrderedAt = message.OrderedAt.ToClientValue();
        }

        #region Properties

        public int InstrumentId { get; }

        public string Id { get; }

        public string RequestId { get; }

        public OrderSide Side { get; }

        public double OutstandingSize { get; }

        public double? Price { get; }

        public double? AveragePrice { get; }

        public OrderState State { get; }

        public OrderType Type { get; }

        public double Size { get; }

        public DateTimeOffset? OrderedAt { get; }

        #endregion

        public bool IsValid =>
            !((Type == OrderType.Limit && Price == 0) ||
              (Type == OrderType.Market && Price != 0) ||
              Type == OrderType.None ||
              Side == OrderSide.None ||
              (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(RequestId)));
    }
}
