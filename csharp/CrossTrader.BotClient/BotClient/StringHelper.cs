namespace CrossTrader.BotClient
{
    internal static class StringHelper
    {
        public static string EmptyToNull(this string s)
            => string.IsNullOrEmpty(s) ? null : s;
    }
}