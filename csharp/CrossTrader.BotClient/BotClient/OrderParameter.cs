using System;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class OrderParameter
    {
        internal OrderParameter(int instrumentId, OrderType type, OrderSide side, double size, double? price, OrderParametersResponse message)
        {
            InstrumentId = instrumentId;
            RequestId = message.RequestId;
            Side = side;
            Type = type;
            Size = size;
            Price = price;
        }

        #region Properties

        public int InstrumentId { get; }

        public string RequestId { get; set; }

        public OrderSide Side { get; set; }

        public OrderType Type { get; set; }

        public double Size { get; set; }

        public double? Price { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        #endregion

        public bool IsValid =>
            !((Type == OrderType.Limit && Price == 0) ||
              (Type == OrderType.Market && Price != 0) ||
              Type == OrderType.None ||
              Side == OrderSide.None ||
              string.IsNullOrEmpty(RequestId));
    }
}
