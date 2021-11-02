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
            => v switch
            {
                ChangedAction.Add => NotifyCollectionChangedAction.Add,
                ChangedAction.Remove => NotifyCollectionChangedAction.Remove,
                ChangedAction.Replace => NotifyCollectionChangedAction.Replace,
                _ => NotifyCollectionChangedAction.Reset,
            };

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OrderSide ToClientValue(this MR.OrderSide v)
            => v switch
            {
                MR.OrderSide.Buy => OrderSide.Buy,
                MR.OrderSide.Sell => OrderSide.Sell,
                _ => OrderSide.None,
            };

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OrderType ToClientValue(this MR.OrderType v)
            => v switch
            {
                MR.OrderType.Limit => OrderType.Limit,
                MR.OrderType.Market => OrderType.Market,
                MR.OrderType.Unknown => OrderType.Unknown,
                _ => OrderType.None,
            };

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OrderState ToClientValue(this MR.OrderState v)
            => v switch
            {
                MR.OrderState.Active => OrderState.Active,
                MR.OrderState.Canceled => OrderState.Canceled,
                MR.OrderState.Canceling => OrderState.Canceling,
                MR.OrderState.Completed => OrderState.Completed,
                MR.OrderState.Expired => OrderState.Expired,
                MR.OrderState.Failed => OrderState.Failed,
                MR.OrderState.Requesting => OrderState.Requesting,
                MR.OrderState.None => OrderState.None,
                _ => OrderState.None,
            };

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BitFlyerChildOrderType ToClientValue(this MBF.ChildOrderType v)
            => v switch
            {
                MBF.ChildOrderType.Limit => BitFlyerChildOrderType.Limit,
                MBF.ChildOrderType.Market => BitFlyerChildOrderType.Market,
                _ => BitFlyerChildOrderType.None,
            };

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BitFlyerChildOrderState ToClientValue(this MBF.ChildOrderState v)
            => v switch
            {
                MBF.ChildOrderState.Active => BitFlyerChildOrderState.Active,
                MBF.ChildOrderState.Completed => BitFlyerChildOrderState.Completed,
                MBF.ChildOrderState.Canceled => BitFlyerChildOrderState.Canceled,
                MBF.ChildOrderState.Expired => BitFlyerChildOrderState.Expired,
                MBF.ChildOrderState.Rejected => BitFlyerChildOrderState.Rejected,
                _ => BitFlyerChildOrderState.None,
            };

        #region BitMEX

        [TargetedPatchingOptOut("")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BitMexTickDirection ToClientValue(this MMEX.TickDirection v)
            => v switch
            {
                MMEX.TickDirection.PlusTick => BitMexTickDirection.PlusTick,
                MMEX.TickDirection.ZeroPlusTick => BitMexTickDirection.ZeroPlusTick,
                MMEX.TickDirection.MinusTick => BitMexTickDirection.MinusTick,
                MMEX.TickDirection.ZeroMinusTick => BitMexTickDirection.ZeroMinusTick,
                _ => BitMexTickDirection.None,
            };

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