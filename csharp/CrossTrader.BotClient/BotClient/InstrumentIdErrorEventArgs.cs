using System;

namespace CrossTrader.BotClient
{
    public sealed class InstrumentIdErrorEventArgs : EventArgs
    {
        internal InstrumentIdErrorEventArgs(int instrumentId, Exception exception)
        {
            InstrumentId = instrumentId;
            Exception = exception;
        }
        public int InstrumentId { get; }
        public Exception Exception { get; }
    }
}