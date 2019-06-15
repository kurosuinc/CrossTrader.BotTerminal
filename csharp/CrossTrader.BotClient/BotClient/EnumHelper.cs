using System.Collections.Specialized;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    internal static class EnumHelper
    {
        public static NotifyCollectionChangedAction ToClientValue(this Models.Remoting.ChangedAction v)
        {
            switch (v)
            {
                case ChangedAction.Add:
                    return NotifyCollectionChangedAction.Add;

                case ChangedAction.Remove:
                    return NotifyCollectionChangedAction.Remove;

                case ChangedAction.Replace:
                    return NotifyCollectionChangedAction.Replace;
            }

            return NotifyCollectionChangedAction.Reset;
        }

        public static OrderSide ToClientValue(this Models.Remoting.OrderSide v)
        {
            switch (v)
            {
                case Models.Remoting.OrderSide.Buy:
                    return OrderSide.Buy;

                case Models.Remoting.OrderSide.Sell:
                    return OrderSide.Sell;
            }
            return OrderSide.None;
        }
    }
}