namespace CrossTrader.BotClient
{
    internal static class OrderTypeExtensions
    {
        public static Models.Remoting.OrderType ToMessage(this OrderType side)
            => side switch
            {
                OrderType.Market => Models.Remoting.OrderType.Market,
                OrderType.Limit => Models.Remoting.OrderType.Limit,
                _ => Models.Remoting.OrderType.None,
            };
    }
}
