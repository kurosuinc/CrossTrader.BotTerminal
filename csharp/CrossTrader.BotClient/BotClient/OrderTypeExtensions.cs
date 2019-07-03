namespace CrossTrader.BotClient
{
    internal static class OrderTypeExtensions
    {
        public static Models.Remoting.OrderType ToMessage(this OrderType side)
        {
            switch (side)
            {
                case OrderType.Market:
                    return Models.Remoting.OrderType.Market;
                case OrderType.Limit:
                    return Models.Remoting.OrderType.Limit;
                default:
                    return Models.Remoting.OrderType.None;
            }
        }
    }
}
