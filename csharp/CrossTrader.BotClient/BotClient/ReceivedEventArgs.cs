using System;

namespace CrossTrader.BotClient
{
    public sealed class ReceivedEventArgs<T> : EventArgs
    {
        internal ReceivedEventArgs(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}