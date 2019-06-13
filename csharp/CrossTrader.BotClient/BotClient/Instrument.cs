using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class Instrument
    {
        internal Instrument(InstrumentMessage message, Exchange exchange = null)
        {
            Exchange = exchange;

            Id = message.Id;
            ExchangeId = message.ExchangeId;
            Name = message.Name;
            DisplayName = message.DisplayName;
            Description = message.Description.EmptyToNull();
            CurrencyCode = message.CurrencyCode;
            CanGetTicker = message.CanGetTicker;
            CanSubscribeTicker = message.CanSubscribeTicker;
            CanGetExecutions = message.CanGetExecutions;
            CanSubscribeExecutions = message.CanSubscribeExecutions;
            SizeDecimals = message.SizeDecimals;
            MinimumSize = message.MinimumSize;
            IsOrderSupported = message.IsOrderSupported;
            CanGetOrders = message.CanGetOrders;
            CanSubscribeOrders = message.CanSubscribeOrders;
            IsPositionSupported = message.IsPositionSupported;
            CanGetPositions = message.CanGetPositions;
            CanSubscribePositions = message.CanSubscribePositions;
        }

        public Exchange Exchange { get; }

        public int Id { get; }
        public int ExchangeId { get; }
        public string Name { get; }
        public string DisplayName { get; }
        public string Description { get; }
        public string CurrencyCode { get; }
        public bool CanGetTicker { get; }
        public bool CanSubscribeTicker { get; }
        public bool CanGetExecutions { get; }
        public bool CanSubscribeExecutions { get; }
        public int SizeDecimals { get; }
        public double MinimumSize { get; }

        public bool IsOrderSupported { get; }
        public bool CanGetOrders { get; }
        public bool CanSubscribeOrders { get; }

        public bool IsPositionSupported { get; }
        public bool CanGetPositions { get; }
        public bool CanSubscribePositions { get; }
    }
}