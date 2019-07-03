namespace CrossTrader.BotClient
{
    internal static class DoubleHelper
    {
        public static double? PositiveOrNull(this double v)
            => v > 0 ? v : (double?)null;
    }
}