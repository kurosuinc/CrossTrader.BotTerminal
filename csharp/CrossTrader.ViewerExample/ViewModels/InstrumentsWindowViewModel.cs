using System;
using System.Collections.ObjectModel;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class InstrumentsWindowViewModel : WindowViewModelBase
    {
        internal InstrumentsWindowViewModel(CrossTraderClient client)
            : base(client)
        { }

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

                _Instruments.Clear();
                foreach (var e in items)
                {
                    _Instruments.Add(new InstrumentViewModel(this, e));
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