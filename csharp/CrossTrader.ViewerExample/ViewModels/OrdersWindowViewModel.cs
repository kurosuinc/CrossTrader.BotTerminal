using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class OrdersWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal OrdersWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.OrdersReceived += Client_OrdersReceived;
            client.OrdersError += Client_OrdersError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new InstrumentViewModel(this, e);

        #region Orders

        public class OrderEntry
        {
            internal OrderEntry(NotifyCollectionChangedAction action, InstrumentViewModel instrument, Order execution)
            {
                Action = action;
                Instrument = instrument;
                Order = execution;
            }

            public NotifyCollectionChangedAction Action { get; }

            public InstrumentViewModel Instrument { get; }
            public Order Order { get; }
        }

        private ObservableCollection<OrderEntry> _Orders;

        public ObservableCollection<OrderEntry> Orders
        {
            get
            {
                if (_Orders == null)
                {
                    _Orders = new ObservableCollection<OrderEntry>();
                    BindingOperations.EnableCollectionSynchronization(_Orders, _Orders);
                }
                return _Orders;
            }
        }

        #endregion Orders

        #region SubscribeOrdersCommand

        private Command _SubscribeOrdersCommand;

        public Command SubscribeOrdersCommand
            => _SubscribeOrdersCommand ?? (_SubscribeOrdersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.SubscribeOrders(i.Id);
                    }
                }
            }));

        #endregion SubscribeOrdersCommand

        #region UnsubscribeOrdersCommand

        private Command _UnsubscribeOrdersCommand;

        public Command UnsubscribeOrdersCommand
            => _UnsubscribeOrdersCommand ?? (_UnsubscribeOrdersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.UnsubscribeOrders(i.Id);
                    }
                }
            }));

        #endregion UnsubscribeOrdersCommand

        private void Client_OrdersReceived(object sender, CollectionReceivedEventArgs<Order> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data[0].InstrumentId);
            if (i != null)
            {
                i.LastError = null;

                lock (Orders)
                {
                    foreach (var m in e.Data)
                    {
                        Orders.Add(new OrderEntry(e.Action, i, m));
                    }

                    const int MAX = 100;
                    while (Orders.Count > 100)
                    {
                        Orders.RemoveAt(Orders.Count - 1 - MAX);
                    }
                }
            }
        }

        private void Client_OrdersError(object sender, InstrumentIdErrorEventArgs e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.InstrumentId);
            if (i != null)
            {
                i.LastError = (e.Exception.GetBaseException() ?? e.Exception).Message;
            }
        }

        protected override void Dispose(bool disposing)
            => Client.Dispose();
    }
}
