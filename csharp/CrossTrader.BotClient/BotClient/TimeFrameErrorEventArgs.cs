using System;

namespace CrossTrader.BotClient
{
    public sealed class TimeFrameErrorEventArgs : EventArgs
    {
        internal TimeFrameErrorEventArgs(int instrumentId, TimeSpan timeFrame, Exception exception)
        {
            InstrumentId = instrumentId;
            TimeFrame = timeFrame;
            Exception = exception;
        }

        public int InstrumentId { get; }
        public TimeSpan TimeFrame { get; }
        public Exception Exception { get; }
    }
}