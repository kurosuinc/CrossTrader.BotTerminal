using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class ExecutionsWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal ExecutionsWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.ExecutionsReceived += Client_ExecutionsReceived;
            client.ExecutionsError += Client_ExecutionsError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new InstrumentViewModel(this, e);

        #region Executions

        public class ExecutionEntry
        {
            internal ExecutionEntry(NotifyCollectionChangedAction action, InstrumentViewModel instrument, Execution execution)
            {
                Action = action;
                Instrument = instrument;
                Execution = execution;
            }

            public NotifyCollectionChangedAction Action { get; }

            public InstrumentViewModel Instrument { get; }
            public Execution Execution { get; }
        }

        private ObservableCollection<ExecutionEntry> _Executions;

        public ObservableCollection<ExecutionEntry> Executions
        {
            get
            {
                if (_Executions == null)
                {
                    _Executions = new ObservableCollection<ExecutionEntry>();
                    BindingOperations.EnableCollectionSynchronization(_Executions, _Executions);
                }
                return _Executions;
            }
        }

        #endregion Executions

        #region SubscribeExecutionsCommand

        private Command _SubscribeExecutionsCommand;

        public Command SubscribeExecutionsCommand
            => _SubscribeExecutionsCommand ?? (_SubscribeExecutionsCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.SubscribeExecutions(i.Id);
                    }
                }
            }));

        #endregion SubscribeExecutionsCommand

        #region UnsubscribeExecutionsCommand

        private Command _UnsubscribeExecutionsCommand;

        public Command UnsubscribeExecutionsCommand
            => _UnsubscribeExecutionsCommand ?? (_UnsubscribeExecutionsCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.UnsubscribeExecutions(i.Id);
                    }
                }
            }));

        #endregion UnsubscribeExecutionsCommand

        private void Client_ExecutionsReceived(object sender, CollectionReceivedEventArgs<Execution> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data[0].InstrumentId);
            if (i != null)
            {
                i.LastError = null;

                lock (Executions)
                {
                    foreach (var m in e.Data)
                    {
                        Executions.Add(new ExecutionEntry(e.Action, i, m));
                    }

                    const int MAX = 100;
                    while (Executions.Count > 100)
                    {
                        Executions.RemoveAt(Executions.Count - 1 - MAX);
                    }
                }
            }
        }

        private void Client_ExecutionsError(object sender, InstrumentIdErrorEventArgs e)
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