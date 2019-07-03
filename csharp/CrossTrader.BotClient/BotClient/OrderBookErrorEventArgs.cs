using System;

namespace CrossTrader.BotClient
{
    public sealed class OrderBookErrorEventArgs : EventArgs
    {
        internal OrderBookErrorEventArgs(int instrumentId, double groupSize, int levelCount, Exception exception)
        {
            InstrumentId = instrumentId;
            GroupSize = groupSize;
            LevelCount = levelCount;
            Exception = exception;
        }

        public int InstrumentId { get; }
        public double GroupSize { get; }

        public int LevelCount { get; }
        public Exception Exception { get; }
    }
}