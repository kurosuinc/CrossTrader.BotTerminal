namespace CrossTrader.BotClient
{
    internal static class OrderSideExtensions
    {
        public static Models.Remoting.OrderSide ToMessage(this OrderSide side)
            => side switch
            {
                OrderSide.Buy => Models.Remoting.OrderSide.Buy,
                OrderSide.Sell => Models.Remoting.OrderSide.Sell,
                _ => Models.Remoting.OrderSide.None,
            };
    }
}
