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
        public string Description => _Instrument.Description;
    }
}