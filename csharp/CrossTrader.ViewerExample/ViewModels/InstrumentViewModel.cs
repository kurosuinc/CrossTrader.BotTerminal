using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class InstrumentViewModel : ViewModelBase
    {
        private readonly InstrumentsWindowViewModel _Window;
        private readonly Instrument _Instrument;

        internal InstrumentViewModel(InstrumentsWindowViewModel window, Instrument instrument)
        {
            _Window = window;
            _Instrument = instrument;
        }

        public int Id => _Instrument.Id;
        public int ExchangeId => _Instrument.ExchangeId;
        public string ExchangeDisplayName => _Instrument.Exchange.DisplayName;
        public string Name => _Instrument.Name;
        public string DisplayName => _Instrument.DisplayName;
        public bool CanGetTicker => _Instrument.CanGetTicker;
        public bool CanSubscribeTicker => _Instrument.CanSubscribeTicker;

        private bool _IsSelected;

        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                var ais = _Window.AllInstrumentsSelected;
                if (SetProperty(ref _IsSelected, value))
                {
                    _Window.RaiseAllInstrumentsSelectedChanged(ais);
                }
            }
        }

        #region Ticker

        #region BestAsk

        private double? _BestAsk;

        public double? BestAsk
        {
            get => _BestAsk;
            private set => SetProperty(ref _BestAsk, value);
        }

        #endregion BestAsk

        #region BestBid

        private double? _BestBid;

        public double? BestBid
        {
            get => _BestBid;
            private set => SetProperty(ref _BestBid, value);
        }

        #endregion BestBid

        internal void Set(Ticker ticker)
        {
            BestAsk = ticker.BestAsk;
            BestBid = ticker.BestBid;
        }

        #endregion Ticker

        #region LastError

        private string _LastError;

        public string LastError
        {
            get => _LastError;
            internal set => SetProperty(ref _LastError, value);
        }

        #endregion LastError
    }
}