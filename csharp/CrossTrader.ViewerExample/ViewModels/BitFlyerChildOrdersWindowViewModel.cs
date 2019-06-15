using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;
using CrossTrader.BotClient.BitFlyer;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class BitFlyerChildOrdersWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal BitFlyerChildOrdersWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.BitFlyer.ChildOrdersReceived += BitFlyer_ChildOrdersReceived;
            client.BitFlyer.ChildOrdersError += BitFlyer_ChildOrdersError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new InstrumentViewModel(this, e);

        #region ChildOrders

        public class ChildOrderEntry
        {
            internal ChildOrderEntry(NotifyCollectionChangedAction action, InstrumentViewModel instrument, BitFlyerChildOrder childOrder)
            {
                Action = action;
                Instrument = instrument;
                ChildOrder = childOrder;
            }

            public NotifyCollectionChangedAction Action { get; }

            public InstrumentViewModel Instrument { get; }
            public BitFlyerChildOrder ChildOrder { get; }
        }

        private ObservableCollection<ChildOrderEntry> _ChildOrders;

        public ObservableCollection<ChildOrderEntry> ChildOrders
        {
            get
            {
                if (_ChildOrders == null)
                {
                    _ChildOrders = new ObservableCollection<ChildOrderEntry>();
                    BindingOperations.EnableCollectionSynchronization(_ChildOrders, _ChildOrders);
                }
                return _ChildOrders;
            }
        }

        #endregion ChildOrders

        #region SubscribeChildOrdersCommand

        private Command _SubscribeChildOrdersCommand;

        public Command SubscribeChildOrdersCommand
            => _SubscribeChildOrdersCommand ?? (_SubscribeChildOrdersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.BitFlyer.SubscribeChildOrders(i.Id);
                    }
                }
            }));

        #endregion SubscribeChildOrdersCommand

        #region UnsubscribeChildOrdersCommand

        private Command _UnsubscribeChildOrdersCommand;

        public Command UnsubscribeChildOrdersCommand
            => _UnsubscribeChildOrdersCommand ?? (_UnsubscribeChildOrdersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.BitFlyer.UnsubscribeChildOrders(i.Id);
                    }
                }
            }));

        #endregion UnsubscribeChildOrdersCommand

        private void BitFlyer_ChildOrdersReceived(object sender, CollectionReceivedEventArgs<BitFlyerChildOrder> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data[0].InstrumentId);
            if (i != null)
            {
                i.LastError = null;

                lock (ChildOrders)
                {
                    foreach (var m in e.Data)
                    {
                        ChildOrders.Add(new ChildOrderEntry(e.Action, i, m));
                    }

                    const int MAX = 100;
                    while (ChildOrders.Count > 100)
                    {
                        ChildOrders.RemoveAt(ChildOrders.Count - 1 - MAX);
                    }
                }
            }
        }

        private void BitFlyer_ChildOrdersError(object sender, InstrumentIdErrorEventArgs e)
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