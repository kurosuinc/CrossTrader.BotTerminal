using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class OrderParameter
    {
        internal OrderParameter(int instrumentId, OrderParametersResponse message)
        {
            InstrumentId = instrumentId;
            OrderId = message.OrderId;
            RequestId = message.RequestId;
            Side = message.Side.ToClientValue();
            Type = message.Type.ToClientValue();
            Size = message.Size;
            Price = message.Price;
        }

        #region Properties

        public int InstrumentId { get; }

        public string OrderId { get; set; }

        public string RequestId { get; set; }

        public OrderSide Side { get; set; }

        public OrderType Type { get; set; }

        public double Size { get; set; }

        public double Price { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        #endregion

        public bool IsValid =>
            !((Type == OrderType.Limit && Price == 0) ||
              (Type == OrderType.Market && Price != 0) ||
              Type == OrderType.None ||
              Side == OrderSide.None ||
              (string.IsNullOrEmpty(OrderId) && string.IsNullOrEmpty(RequestId)));
    }
}
