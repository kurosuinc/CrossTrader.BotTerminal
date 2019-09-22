using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using CrossTrader.BotClient;

namespace CrossTrader.ViewerExample.ViewModels
{
    public sealed class PositionsWindowViewModel : InstrumentsWindowViewModelBase<InstrumentViewModel>
    {
        internal PositionsWindowViewModel(CrossTraderClient client)
            : base(client)
        {
            client.PositionsReceived += Client_PositionsReceived;
            client.PositionsError += Client_PositionsError;
        }

        protected override InstrumentViewModel GetItem(Instrument e)
            => new InstrumentViewModel(this, e);

        #region Positions

        public class PositionEntry
        {
            internal PositionEntry(NotifyCollectionChangedAction action, InstrumentViewModel instrument, Position execution)
            {
                Action = action;
                Instrument = instrument;
                Position = execution;
            }

            public NotifyCollectionChangedAction Action { get; }

            public InstrumentViewModel Instrument { get; }
            public Position Position { get; }
        }

        private ObservableCollection<PositionEntry> _Positions;

        public ObservableCollection<PositionEntry> Positions
        {
            get
            {
                if (_Positions == null)
                {
                    _Positions = new ObservableCollection<PositionEntry>();
                    BindingOperations.EnableCollectionSynchronization(_Positions, _Positions);
                }
                return _Positions;
            }
        }

        private ObservableCollection<PositionEntry> _ActivePositions;

        public ObservableCollection<PositionEntry> ActivePositions
        {
            get
            {
                if (_ActivePositions == null)
                {
                    _ActivePositions = new ObservableCollection<PositionEntry>();
                    BindingOperations.EnableCollectionSynchronization(_ActivePositions, _ActivePositions);
                }
                return _ActivePositions;
            }
        }

        #endregion Positions

        #region SubscribePositionsCommand

        private Command _SubscribePositionsCommand;

        public Command SubscribePositionsCommand
            => _SubscribePositionsCommand ?? (_SubscribePositionsCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.SubscribePositions(i.Id);
                    }
                }
            }));

        #endregion SubscribePositionsCommand

        #region UnsubscribePositionsCommand

        private Command _UnsubscribePositionsCommand;

        public Command UnsubscribePositionsCommand
            => _UnsubscribePositionsCommand ?? (_UnsubscribePositionsCommand = Command.Create(() =>
            {
                foreach (var i in Instruments)
                {
                    if (i.IsSelected)
                    {
                        Client.UnsubscribePositions(i.Id);
                    }
                }
            }));

        #endregion UnsubscribePositionsCommand

        private void Client_PositionsReceived(object sender, CollectionReceivedEventArgs<Position> e)
        {
            var i = Instruments.FirstOrDefault(m => m.Id == e.Data[0].InstrumentId);
            if (i != null)
            {
                i.LastError = null;

                lock (Positions)
                {
                    foreach (var m in e.Data)
                    {
                        Positions.Add(new PositionEntry(e.Action, i, m));
                    }

                    const int MAX = 100;
                    while (Positions.Count > 100)
                    {
                        Positions.RemoveAt(Positions.Count - 1 - MAX);
                    }
                }
                lock (ActivePositions)
                {
                    var activePositions = ActivePositions.Where(p => p.Instrument.Id.Equals(i.Id)).ToList();
                    var xs = e.Data.Distinct();
                    foreach (var m in xs)
                    {
                        var currents = activePositions.Where(ap => ap.Position.Id == m.Id);
                        if (currents.Count() == 0 && e.Action == NotifyCollectionChangedAction.Add)
                        {
                            ActivePositions.Add(new PositionEntry(e.Action, i, m));
                        } else if (currents.Count() > 0 && e.Action == NotifyCollectionChangedAction.Remove)
                        {
                            foreach (var current in currents)
                            {
                                ActivePositions.Remove(current);
                            }
                        } else if (currents.Count() > 0 && (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace))
                        {
                            foreach (var current in currents)
                            {
                                ActivePositions.Remove(current);
                            }
                            ActivePositions.Add(new PositionEntry(e.Action, i, m));
                        }
                    }
                }
            }
        }

        private void Client_PositionsError(object sender, InstrumentIdErrorEventArgs e)
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
