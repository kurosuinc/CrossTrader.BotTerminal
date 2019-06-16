using System;
using CrossTrader.Models.Remoting.BitFlyer;

namespace CrossTrader.BotClient.BitFlyer
{
    public sealed class BitFlyerChildOrder
    {
        internal BitFlyerChildOrder(int instrumentId, ChildOrderMessage message)
        {
            InstrumentId = instrumentId;

            Id = message.Id;
            ChildOrderId = message.ChildOrderId.EmptyToNull();
            Side = message.Side.ToClientValue();
            ChildOrderType = message.ChildOrderType.ToClientValue();
            Price = message.Price.PositiveOrNull();
            AveragePrice = message.AveragePrice.PositiveOrNull();
            Size = message.Size.PositiveOrNull();
            ChildOrderState = message.ChildOrderState.ToClientValue();
            ExpireDate = message.ExpireDate.ToClientValue() ?? default;
            ChildOrderDate = message.ChildOrderDate.ToClientValue() ?? default;
            ChildOrderAcceptanceId = message.ChildOrderAcceptanceId.EmptyToNull();
            OutstandingSize = message.OutstandingSize;
            CancelSize = message.CancelSize;
            ExecutedSize = message.ExecutedSize;
            TotalCommission = message.TotalCommission;
        }

        public int InstrumentId { get; }

        public long Id { get; }
        public string ChildOrderId { get; }
        public OrderSide Side { get; }
        public BitFlyerChildOrderType ChildOrderType { get; }
        public double? Price { get; }
        public double? AveragePrice { get; }
        public double? Size { get; }
        public BitFlyerChildOrderState ChildOrderState { get; }
        public DateTimeOffset ExpireDate { get; }
        public DateTimeOffset ChildOrderDate { get; }
        public string ChildOrderAcceptanceId { get; }
        public double OutstandingSize { get; }
        public double CancelSize { get; }
        public double ExecutedSize { get; }
        public double TotalCommission { get; }

        internal bool IsValid
            => ChildOrderDate > DateTimeOffset.MinValue;
    }
}