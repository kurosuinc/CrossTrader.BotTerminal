using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
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
        private static Dictionary<T1, T2> GetEnumDictionary<T1, T2>()
            where T1 : Enum
            where T2 : Enum
        {
            const BindingFlags F = BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly;
            FieldInfo[] fs1, fs2;
#if NETSTANDARD1_5
            fs1 = typeof(T1).GetTypeInfo().GetFields(F);
            fs2 = typeof(T2).GetTypeInfo().GetFields(F);
#else
            fs1 = typeof(T1).GetFields(F);
            fs2 = typeof(T1).GetFields(F);
#endif
            var d = new Dictionary<T1, T2>();
            foreach (var f1 in fs1)
            {
                var f2 = fs2.FirstOrDefault(e => e.Name == f1.Name);
                if (f2 != null)
                {
                    d[(T1)f1.GetValue(null)] = (T2)f2.GetValue(null);
                }
            }
            return d;
        }

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NotifyCollectionChangedAction ToClientValue(this ChangedAction v)
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

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OrderType ToClientValue(this MR.OrderType v)
        {
            switch (v)
            {
                case MR.OrderType.Limit:
                    return OrderType.Limit;

                case MR.OrderType.Market:
                    return OrderType.Market;

                case MR.OrderType.Unknown:
                    return OrderType.Unknown;
            }
            return OrderType.None;
        }

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OrderState ToClientValue(this MR.OrderState v)
        {
            switch (v)
            {
                case MR.OrderState.Active:
                    return OrderState.Active;
                case MR.OrderState.Canceled:
                    return OrderState.Canceled;
                case MR.OrderState.Canceling:
                    return OrderState.Canceling;
                case MR.OrderState.Completed:
                    return OrderState.Completed;
                case MR.OrderState.Expired:
                    return OrderState.Expired;
                case MR.OrderState.Failed:
                    return OrderState.Failed;
                case MR.OrderState.Requesting:
                    return OrderState.Requesting;
                case MR.OrderState.None:
                    return OrderState.None;
            }
            return OrderState.None;
        }

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        #region BitMEX

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        #region BitMexOrderType

        // TODO: 気が向いたら手書き+テストに直す

        private static readonly Dictionary<MMEX.OrderType, BitMexOrderType> _BitMexOrderTypes
            = GetEnumDictionary<MMEX.OrderType, BitMexOrderType>();

        public static BitMexOrderType ToClientValue(this MMEX.OrderType v)
            => _BitMexOrderTypes.TryGetValue(v, out var r) ? r : BitMexOrderType.None;

        #endregion BitMexOrderType

        #region BitMexTimeInForce

        // TODO: 気が向いたら手書き+テストに直す

        private static readonly Dictionary<MMEX.TimeInForce, BitMexTimeInForce> _BitMexTimeInForces
            = GetEnumDictionary<MMEX.TimeInForce, BitMexTimeInForce>();

        public static BitMexTimeInForce ToClientValue(this MMEX.TimeInForce v)
            => _BitMexTimeInForces.TryGetValue(v, out var r) ? r : BitMexTimeInForce.None;

        #endregion BitMexTimeInForce

        #region BitMexOrderStatus

        // TODO: 気が向いたら手書き+テストに直す

        private static readonly Dictionary<MMEX.OrderStatus, BitMexOrderStatus> _BitMexOrderStatuss
            = GetEnumDictionary<MMEX.OrderStatus, BitMexOrderStatus>();

        public static BitMexOrderStatus ToClientValue(this MMEX.OrderStatus v)
            => _BitMexOrderStatuss.TryGetValue(v, out var r) ? r : BitMexOrderStatus.None;

        #endregion BitMexOrderStatus

        #endregion BitMEX
    }
}