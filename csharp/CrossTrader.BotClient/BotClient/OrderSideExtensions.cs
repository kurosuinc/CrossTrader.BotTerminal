namespace CrossTrader.BotClient
{
    internal static class OrderSideExtensions
    {
        public static Models.Remoting.OrderSide ToMessage(this OrderSide side)
        {
            switch (side)
            {
                case OrderSide.Buy:
                    return Models.Remoting.OrderSide.Buy;
                case OrderSide.Sell:
                    return Models.Remoting.OrderSide.Sell;
                default:
                    return Models.Remoting.OrderSide.None;
            }
        }
    }
}
