using System;
using System.Collections.ObjectModel;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class ExchangesWindowViewModel : WindowViewModelBase
    {
        internal ExchangesWindowViewModel(CrossTraderClient client)
            : base(client)
        { }

        #region Exchanges

        private ObservableCollection<Exchange> _Exchanges;

        public ObservableCollection<Exchange> Exchanges
        {
            get
            {
                if (_Exchanges == null)
                {
                    _Exchanges = new ObservableCollection<Exchange>();

                    LoadExchanges();
                }
                return _Exchanges;
            }
        }

        private async void LoadExchanges()
        {
            try
            {
                IsBusy = true;

                var items = await Client.GetExchangesAsync();

                _Exchanges.Clear();
                foreach (var e in items)
                {
                    _Exchanges.Add(e);
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

        #endregion Exchanges

        #region SelectedExchange

        private Exchange _SelectedExchange;

        public Exchange SelectedExchange
        {
            get => _SelectedExchange;
            set => SetProperty(ref _SelectedExchange, value, onChanged: LoadInstruments);
        }

        #endregion SelectedExchange

        #region Instruments

        private ObservableCollection<Instrument> _Instruments;

        public ObservableCollection<Instrument> Instruments
        {
            get
            {
                if (_Instruments == null)
                {
                    _Instruments = new ObservableCollection<Instrument>();

                    LoadInstruments();
                }
                return _Instruments;
            }
        }

        private async void LoadInstruments()
        {
            if (_Instruments == null)
            {
                return;
            }

            var eid = _SelectedExchange?.Name;
            if (eid == null)
            {
                _Instruments.Clear();
                return;
            }
            try
            {
                IsBusy = true;

                var items = await Client.GetExchangeAsync(eid);

                if (eid == _SelectedExchange?.Name)
                {
                    _Instruments.Clear();
                    if (items != null)
                    {
                        foreach (var e in items.Instruments)
                        {
                            _Instruments.Add(e);
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

        #endregion Instruments

        protected override void Dispose(bool disposing)
            => Client.Dispose();
    }
}