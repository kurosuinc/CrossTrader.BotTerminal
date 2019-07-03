using CrossTrader.Models.Remoting;

namespace CrossTrader.BotClient
{
    public sealed class OrderLevel
    {
        internal OrderLevel(OrderLevelMessage message)
        {
            Lowerbound = message.Lowerbound;
            Volume = message.Volume;
        }
        public double Lowerbound { get; }
        public double Volume { get; }
    }
}