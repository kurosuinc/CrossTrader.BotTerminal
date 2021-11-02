using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;
using CrossTrader.BotClient.BitMex;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class BitMexTradesWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal BitMexTradesWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.BitMex.TradesReceived += BitMex_TradesReceived;
            client.BitMex.TradesError += BitMex_TradesError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new(this, e);

        #region Trades

        public class TradeEntry
        {
            internal TradeEntry(NotifyCollectionChangedAction action, InstrumentViewModel instrument, BitMexTrade trade)
            {
                Action = action;
                Instrument = instrument;
                Trade = trade;
            }

            public NotifyCollectionChangedAction Action { get; }

            public InstrumentViewModel Instrument { get; }
            public BitMexTrade Trade { get; }
        }

        private ObservableCollection<TradeEntry> _Trades;

        public ObservableCollection<TradeEntry> Trades
        {
            get
            {
                if (_Trades == null)
                {
                    _Trades = new ObservableCollection<TradeEntry>();
                    BindingOperations.EnableCollectionSynchronization(_Trades, _Trades);
                }
                return _Trades;
            }
        }

        #endregion Trades

        #region SubscribeTradesCommand

        private Command _SubscribeTradesCommand;

        public Command SubscribeTradesCommand
            => _SubscribeTradesCommand ?? (_SubscribeTradesCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.BitMex.SubscribeTrades(i.Id);
                    }
                }
            }));

        #endregion SubscribeTradesCommand

        #region UnsubscribeTradesCommand

        private Command _UnsubscribeTradesCommand;

        public Command UnsubscribeTradesCommand
            => _UnsubscribeTradesCommand ?? (_UnsubscribeTradesCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.BitMex.UnsubscribeTrades(i.Id);
                    }
                }
            }));

        #endregion UnsubscribeTradesCommand

        private void BitMex_TradesReceived(object sender, CollectionReceivedEventArgs<BitMexTrade> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data[0].InstrumentId);
            if (i != null)
            {
                i.LastError = null;

                lock (Trades)
                {
                    foreach (var m in e.Data)
                    {
                        Trades.Add(new TradeEntry(e.Action, i, m));
                    }

                    const int MAX = 100;
                    while (Trades.Count > 100)
                    {
                        Trades.RemoveAt(Trades.Count - 1 - MAX);
                    }
                }
            }
        }

        private void BitMex_TradesError(object sender, InstrumentIdErrorEventArgs e)
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