using System.Collections.Specialized;
using CrossTrader.BotClient.BitFlyer;
using CrossTrader.BotClient.BitMex;
using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    using MBF = Models.Remoting.BitFlyer;
    using MMEX = Models.Remoting.BitMex;
    using MR = Models.Remoting;

    internal static class EnumHelper
    {
        public static NotifyCollectionChangedAction ToClientValue(this MR.ChangedAction v)
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

        public static OrderSide ToClientValue(this MR.OrderSide v)
        {
            switch (v)
            {
                case MR.OrderSide.Buy:
                    return OrderSide.Buy;

                case MR.OrderSide.Sell:
                    return OrderSide.Sell;
            }
            return OrderSide.None;
        }

        public static BitFlyerChildOrderType ToClientValue(this MBF.ChildOrderType v)
        {
            switch (v)
            {
                case MBF.ChildOrderType.Limit:
                    return BitFlyerChildOrderType.Limit;

                case MBF.ChildOrderType.Market:
                    return BitFlyerChildOrderType.Market;
            }
            return BitFlyerChildOrderType.None;
        }

        public static BitFlyerChildOrderState ToClientValue(this MBF.ChildOrderState v)
        {
            switch (v)
            {
                case MBF.ChildOrderState.Active:
                    return BitFlyerChildOrderState.Active;

                case MBF.ChildOrderState.Completed:
                    return BitFlyerChildOrderState.Completed;

                case MBF.ChildOrderState.Canceled:
                    return BitFlyerChildOrderState.Canceled;

                case MBF.ChildOrderState.Expired:
                    return BitFlyerChildOrderState.Expired;

                case MBF.ChildOrderState.Rejected:
                    return BitFlyerChildOrderState.Rejected;

            }
            return BitFlyerChildOrderState.None;
        }

        public static BitMexTickDirection ToClientValue(this MMEX.TickDirection v)
        {
            switch (v)
            {
                case MMEX.TickDirection.PlusTick:
                    return BitMexTickDirection.PlusTick;

                case MMEX.TickDirection.ZeroPlusTick:
                    return BitMexTickDirection.ZeroPlusTick;

                case MMEX.TickDirection.MinusTick:
                    return BitMexTickDirection.MinusTick;

                case MMEX.TickDirection.ZeroMinusTick:
                    return BitMexTickDirection.ZeroMinusTick;
            }
            return BitMexTickDirection.None;
        }
    }
}