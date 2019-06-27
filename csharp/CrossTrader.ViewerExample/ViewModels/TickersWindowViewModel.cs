using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CrossTrader.BotClient;
using CrossTrader.ViewerExample.Views;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class TickersWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal TickersWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.TickerReceived += Client_TickerReceived;
            client.TickerError += Client_TickerError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new InstrumentViewModel(this, e);

        #region SelectedInstrument

        private InstrumentViewModel _SelectedInstrument;
        public InstrumentViewModel SelectedInstrument
        {
            get => _SelectedInstrument;
            set => SetProperty(ref _SelectedInstrument, value);
        }

        #endregion

        #region RefreshTickersCommand

        private Command _RefreshTickersCommand;

        public ICommand RefreshTickersCommand
            => _RefreshTickersCommand
            ?? (_RefreshTickersCommand = Command.Create(async () =>
            {
                var items = Instruments.Where(e => e.IsSelected).ToList();
                if (items.Any())
                {
                    try
                    {
                        IsBusy = true;

                        var tasks = items.Select(e => Client.GetTickerAsync(e.Id)).ToList();
                        var tickers = Task.WhenAll(tasks);
                        try
                        {
                            await tickers;
                        }
                        catch { }

                        for (var i = 0; i < items.Count; i++)
                        {
                            var item = items[i];
                            var task = tasks[i];
                            var current = Instruments.FirstOrDefault(e => e.Id == item.Id);
                            if (current != null)
                            {
                                if (task.Status == TaskStatus.RanToCompletion)
                                {
                                    if (task.Result == null)
                                    {
                                        current.LastError = "Returned null";
                                    }
                                    else
                                    {
                                        current.Set(task.Result);
                                        current.LastError = null;
                                    }
                                }
                                else if (task.Exception != null)
                                {
                                    current.LastError = (task.Exception?.GetBaseException() ?? task.Exception)?.Message;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex.ToString());
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }
            }));

        #endregion RefreshTickersCommand

        #region SubscribeTickersCommand

        private Command _SubscribeTickersCommand;

        public Command SubscribeTickersCommand
            => _SubscribeTickersCommand ?? (_SubscribeTickersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.SubscribeTicker(i.Id);
                    }
                }
            }));

        #endregion SubscribeTickersCommand

        #region UnsubscribeTickersCommand

        private Command _UnsubscribeTickersCommand;

        public Command UnsubscribeTickersCommand
            => _UnsubscribeTickersCommand ?? (_UnsubscribeTickersCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.UnsubscribeTicker(i.Id);
                    }
                }
            }));

        #endregion UnsubscribeTickersCommand

        private Command _ShowOrderBookCommand;
        public Command ShowOrderBookCommand
            => _ShowOrderBookCommand ?? (_ShowOrderBookCommand = Command.Create(() =>
            {
                if (_SelectedInstrument != null)
                {
                    new OrderBookWindow()
                    {
                        DataContext = new OrderBookWindowViewModel(Client, _SelectedInstrument._Instrument),
                    }.ShowDialog();
                }
            }));

        private void Client_TickerReceived(object sender, ReceivedEventArgs<Ticker> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data.InstrumentId);
            if (i != null)
            {
                i.Set(e.Data);
                i.LastError = null;
            }
        }

        private void Client_TickerError(object sender, InstrumentIdErrorEventArgs e)
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