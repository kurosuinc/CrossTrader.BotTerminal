using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using CrossTrader.Models.Remoting;
#if !NETSTANDARD1_5
using System.Collections.ObjectModel;
#endif

namespace CrossTrader.BotClient
{
    public sealed class CollectionReceivedEventArgs<T> : EventArgs
    {
        internal CollectionReceivedEventArgs(ChangedAction action, IEnumerable<T> data)
        {
            Action = action.ToClientValue();
            var ary = data.ToArray();
#if NETSTANDARD1_5
            Data = ary;
#else
            Data = Array.AsReadOnly(ary);
#endif
        }

        public NotifyCollectionChangedAction Action { get; }
#if NETSTANDARD1_5
        public IReadOnlyList<T> Data { get; }
#else
        public ReadOnlyCollection<T> Data { get; }
#endif
    }
}