using System.Windows.Input;
using CrossTrader.BotClient;
using CrossTrader.ViewerExample.Properties;
using CrossTrader.ViewerExample.Views;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class LoginWindowViewModel : WindowViewModelBase
    {
        public LoginWindowViewModel()
            : base(null)
        {
            var sd = Settings.Default;
            _Host = sd.Host;
            _Port = sd.Port;
        }

        #region Host

        private string _Host;

        public string Host
        {
            get => _Host;
            set => SetProperty(ref _Host, value ?? string.Empty);
        }

        #endregion Host

        #region Port

        private ushort _Port;

        public ushort Port
        {
            get => _Port;
            set => SetProperty(ref _Port, value);
        }

        #endregion Port

        #region ShowExchangesCommand

        private Command _ShowExchangesCommand;

        public ICommand ShowExchangesCommand
            => _ShowExchangesCommand
            ?? (_ShowExchangesCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new ExchangesWindow()
                {
                    DataContext = new ExchangesWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowExchangesCommand

        #region ShowTickersCommand

        private Command _ShowTickersCommand;

        public ICommand ShowTickersCommand
            => _ShowTickersCommand
            ?? (_ShowTickersCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new TickersWindow()
                {
                    DataContext = new TickersWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowTickersCommand

        #region ShowExecutionsCommand

        private Command _ShowExecutionsCommand;

        public ICommand ShowExecutionsCommand
            => _ShowExecutionsCommand
            ?? (_ShowExecutionsCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new ExecutionsWindow()
                {
                    DataContext = new ExecutionsWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowExecutionsCommand

        #region ShowBitFlyerExecutionsCommand

        private Command _ShowBitFlyerExecutionsCommand;

        public ICommand ShowBitFlyerExecutionsCommand
            => _ShowBitFlyerExecutionsCommand
            ?? (_ShowBitFlyerExecutionsCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new BitFlyerExecutionsWindow()
                {
                    DataContext = new BitFlyerExecutionsWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowBitFlyerExecutionsCommand

        #region ShowBitFlyerChildOrdersCommand

        private Command _ShowBitFlyerChildOrdersCommand;

        public ICommand ShowBitFlyerChildOrdersCommand
            => _ShowBitFlyerChildOrdersCommand
            ?? (_ShowBitFlyerChildOrdersCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new BitFlyerChildOrdersWindow()
                {
                    DataContext = new BitFlyerChildOrdersWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowBitFlyerChildOrdersCommand

        #region ShowBitMexTradesCommand

        private Command _ShowBitMexTradesCommand;

        public ICommand ShowBitMexTradesCommand
            => _ShowBitMexTradesCommand
            ?? (_ShowBitMexTradesCommand = Command.Create(() =>
            {
                var sd = Settings.Default;
                sd.Host = _Host;
                sd.Port = _Port;
                sd.Save();

                new BitMexTradesWindow()
                {
                    DataContext = new BitMexTradesWindowViewModel(new CrossTraderClient()
                    {
                        Host = _Host,
                        Port = _Port
                    })
                }.Show();
            }));

        #endregion ShowBitMexTradesCommand
    }
}