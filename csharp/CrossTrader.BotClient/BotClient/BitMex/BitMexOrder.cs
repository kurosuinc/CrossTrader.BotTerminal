using System;
using CrossTrader.Models.Remoting.BitMex;

namespace CrossTrader.BotClient.BitMex
{
    public sealed class BitMexOrder
    {
        internal BitMexOrder(int instrumentId, OrderMessage message)
        {
            InstrumentId = instrumentId;

            OrderId = Guid.TryParse(message.OrderId, out var oid) ? oid : default;
            ClinetOrderId = message.ClinetOrderId.EmptyToNull();
            ClinetOrderLinkId = message.ClinetOrderLinkId.EmptyToNull();
            Side = message.Side.ToClientValue();
            SimpleOrderQuantity = message.SimpleOrderQuantity;
            OrderQuantity = message.OrderQuantity;
            Price = message.Price.PositiveOrNull();
            DisplayQuantity = message.DisplayQuantity.PositiveOrNull();
            StopPrice = message.StopPrice.PositiveOrNull();
            PegOffsetValue = message.PegOffsetValue.PositiveOrNull();
            PegPriceType = message.PegPriceType;
            OrderType = message.OrderType.ToClientValue();
            TimeInForce = message.TimeInForce.ToClientValue();
            ExecutionInstruction = message.ExecutionInstruction?.EmptyToNull();
            OrderStatus = message.OrderStatus.ToClientValue();
            SimpleLeavesQuantity = message.SimpleLeavesQuantity;
            LeavesQuantity = message.LeavesQuantity;
            AveragePrice = message.AveragePrice.PositiveOrNull();
            Text = message.Text?.EmptyToNull();
            TransactTime = message.TransactTime.ToClientValue();
            Timestamp = message.Timestamp.ToClientValue() ?? default;
        }

        public int InstrumentId { get; }

        public Guid OrderId { get; }
        public string ClinetOrderId { get; }

        public string ClinetOrderLinkId { get; }

        public OrderSide Side { get; }

        public double SimpleOrderQuantity { get; }

        public double OrderQuantity { get; }

        public double? Price { get; }

        public double? DisplayQuantity { get; }

        public double? StopPrice { get; }

        public double? PegOffsetValue { get; }

        public string PegPriceType { get; }

        public BitMexOrderType OrderType { get; }

        public BitMexTimeInForce TimeInForce { get; }

        public string ExecutionInstruction { get; }

        public BitMexOrderStatus OrderStatus { get; }

        public double SimpleLeavesQuantity { get; }

        public double LeavesQuantity { get; }

        public double? AveragePrice { get; }

        public string Text { get; }

        public DateTimeOffset? TransactTime { get; }

        public DateTimeOffset Timestamp { get; }

        internal bool IsValid
            => OrderType != BitMexOrderType.None;
    }
}