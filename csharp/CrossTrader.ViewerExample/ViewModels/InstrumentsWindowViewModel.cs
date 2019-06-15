using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class InstrumentsWindowViewModel : WindowViewModelBase
    {
        internal InstrumentsWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.TickerReceived += Client_TickerReceived;
            client.TickerError += Client_TickerError;
        }


        #region Instruments

        private ObservableCollection<InstrumentViewModel> _Instruments;

        public ObservableCollection<InstrumentViewModel> Instruments
        {
            get
            {
                if (_Instruments == null)
                {
                    _Instruments = new ObservableCollection<InstrumentViewModel>();

                    LoadInstruments();
                }
                return _Instruments;
            }
        }

        private async void LoadInstruments()
        {
            try
            {
                IsBusy = true;

                var items = await Client.GetInstrumentsAsync();

                var ais = AllInstrumentsSelected;
                _Instruments.Clear();
                foreach (var e in items)
                {
                    _Instruments.Add(new InstrumentViewModel(this, e));
                }

                RaiseAllInstrumentsSelectedChanged(ais);
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

        #endregion Instruments

        #region AllInstrumentsSelected

        private bool? _NewAllInstrumentsSelected;
        private bool? _AllInstrumentsSelected;

        public bool? AllInstrumentsSelected
        {
            get => _NewAllInstrumentsSelected
                ?? (!(_Instruments?.Count > 0) || _Instruments.All(e => !e.IsSelected) ? false
                : _Instruments.All(e => e.IsSelected) ? true
                : (bool?)null);
            set
            {
                if (value != AllInstrumentsSelected && value != null)
                {
                    _NewAllInstrumentsSelected = value;
                    foreach (var i in Instruments)
                    {
                        i.IsSelected = value.Value;
                    }
                    _NewAllInstrumentsSelected = null;
                    RaisePropertyChanged();
                }
            }
        }

        internal void RaiseAllInstrumentsSelectedChanged(bool? previousValue)
        {
            if (AllInstrumentsSelected != previousValue)
            {
                RaisePropertyChanged(nameof(AllInstrumentsSelected));
            }
        }

        #endregion AllInstrumentsSelected

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

                        for (int i = 0; i < items.Count; i++)
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