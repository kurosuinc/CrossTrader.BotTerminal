using System.Collections.Generic;
using System.Linq;
using CrossTrader.Models.Remoting;

#if !NETSTANDARD1_5
using System;
using System.Collections.ObjectModel;
#endif

namespace CrossTrader.BotClient
{
    public sealed class OrderBook
    {
        internal OrderBook(int instrumentId, double groupSize,int levelCount, OrderBookResponse message)
        {
            InstrumentId = instrumentId;
            GroupSize = groupSize;
            LevelCount = levelCount;
#if NETSTANDARD1_5
            Asks = message.Asks.Select(e => new OrderLevel(e)).ToArray();
            Bids = message.Bids.Select(e => new OrderLevel(e)).ToArray();
#else
            Asks = Array.AsReadOnly(message.Asks.Select(e => new OrderLevel(e)).ToArray());
            Bids = Array.AsReadOnly(message.Bids.Select(e => new OrderLevel(e)).ToArray());
#endif
        }

        public int InstrumentId { get; }

        public double GroupSize { get; }
       
        public int LevelCount { get; }

#if NETSTANDARD1_5
        public IReadOnlyList<OrderLevel> Asks { get; }
        public IReadOnlyList<OrderLevel> Bids { get; }
#else
        public ReadOnlyCollection<OrderLevel> Asks { get; }
        public ReadOnlyCollection<OrderLevel> Bids { get; }
#endif
        internal bool IsValid => Asks.Any() || Bids.Any();
    }
}