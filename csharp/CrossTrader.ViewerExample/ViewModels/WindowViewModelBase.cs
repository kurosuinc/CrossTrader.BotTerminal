using System.Linq;
using System.Windows;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public abstract class WindowViewModelBase : ViewModelBase
    {
        protected WindowViewModelBase(CrossTraderClient client)
            => Client = client;

        public CrossTraderClient Client { get; }

        private Window _Window;

        internal Window Window
            => _Window
            ?? (_Window = Application.Current?.Windows.OfType<Window>().FirstOrDefault(e => e.DataContext == this));

        private bool _IsBusy;

        public bool IsBusy
        {
            get => _IsBusy;
            protected set => SetProperty(ref _IsBusy, value, onChanged: () => RaisePropertyChanged(nameof(IsNotBusy)));
        }

        public bool IsNotBusy => !_IsBusy;

        internal void ShowErrorMessage(string message)
            => MessageBox.Show(message);

        public void Close()
            => Window?.Close();
    }
}