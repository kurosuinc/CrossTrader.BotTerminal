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

        public string Id { get; set; }

        public string RequestId { get; set; }

        public OrderSide Side { get; set; }

        double OutstandingSize { get; set; }

        public double? Price { get; set; }

        public double? AveragePrice { get; set; }

        public OrderState State { get; set; }

        public OrderType Type { get; set; }

        public double Size { get; set; }

        public DateTimeOffset? OrderedAt { get; set; }

        #endregion

        public bool IsValid =>
            !((Type == OrderType.Limit && Price == 0) ||
              (Type == OrderType.Market && Price != 0) ||
              Type == OrderType.None ||
              Side == OrderSide.None ||
              (string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(RequestId)));
    }
}
