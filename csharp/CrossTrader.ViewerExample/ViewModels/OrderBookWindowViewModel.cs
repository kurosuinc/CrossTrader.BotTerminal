using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class OrderBookWindowViewModel : WindowViewModelBase
    {
        private readonly object _SyncRoot;
        internal OrderBookWindowViewModel(CrossTraderClient client, Instrument instrument)
            : base(client)
        {
            Instrument = instrument;
            _SyncRoot = new object();
            Asks = new ObservableCollection<OrderLevel>();
            Bids = new ObservableCollection<OrderLevel>();

            BindingOperations.EnableCollectionSynchronization(Asks, _SyncRoot);
            BindingOperations.EnableCollectionSynchronization(Bids, _SyncRoot);

            Client.OrderBookReceived += Client_OrderBookReceived;

            Client.SubscribeOrderBook(instrument.Id, 0, 25);
        }

        private void Client_OrderBookReceived(object sender, ReceivedEventArgs<OrderBook> e)
        {
            lock (_SyncRoot)
            {
                void merge(ReadOnlyCollection<OrderLevel> values, ObservableCollection<OrderLevel> dest)
                {
                    if (values.Any())
                    {
                        var newList = values.Concat(dest)
                                        .GroupBy(m => m.Lowerbound)
                                        .Select(m => m.First())
                                        .Where(m => m.Volume > 0)
                                        .OrderByDescending(m => m.Lowerbound)
                                        .ToList();
                        dest.Clear();
                        foreach (var m in newList)
                        {
                            dest.Add(m);
                        }
                    }
                }

                merge(e.Data.Asks, Asks);
                merge(e.Data.Bids, Bids);
            }
        }

        public Instrument Instrument { get; }

        public ObservableCollection<OrderLevel> Asks { get; }
        public ObservableCollection<OrderLevel> Bids { get; }

        protected override void Dispose(bool disposing)
        {
            Client.OrderBookReceived -= Client_OrderBookReceived;
            Client.UnsubscribeOrderBook(Instrument.Id, 0, 25);
        }
    }
}