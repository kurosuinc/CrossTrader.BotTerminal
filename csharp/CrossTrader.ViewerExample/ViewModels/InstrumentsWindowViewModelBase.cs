using System;
using System.Collections.ObjectModel;
using System.Linq;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public abstract class InstrumentsWindowViewModelBase : WindowViewModelBase
    {
        internal InstrumentsWindowViewModelBase(CrossTraderClient client)
            : base(client)
        {
        }

        public abstract bool? AllInstrumentsSelected { get; set; }

        internal void RaiseAllInstrumentsSelectedChanged(bool? previousValue)
        {
            if (AllInstrumentsSelected != previousValue)
            {
                RaisePropertyChanged(nameof(AllInstrumentsSelected));
            }
        }
    }

    public abstract class InstrumentsWindowViewModelBase<T> : InstrumentsWindowViewModelBase
        where T : InstrumentViewModel
    {
        internal InstrumentsWindowViewModelBase(CrossTraderClient client)
            : base(client)
        {
        }

        #region AllInstrumentsSelected

        private bool? _NewAllInstrumentsSelected;

        public override bool? AllInstrumentsSelected
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

        #endregion AllInstrumentsSelected

        #region Instruments

        private ObservableCollection<T> _Instruments;

        public ObservableCollection<T> Instruments
        {
            get
            {
                if (_Instruments == null)
                {
                    _Instruments = new ObservableCollection<T>();

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
                Instruments.Clear();
                foreach (var e in items)
                {
                    Instruments.Add(GetItem(e));
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

        protected abstract T GetItem(Instrument e);

        #endregion Instruments
    }
}