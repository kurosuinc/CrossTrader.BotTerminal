namespace CrossTrader.BotClient.BitMex
{
    public enum BitMexTimeInForce
    {
        None = 0,
        GoodTillCancel = 1,
        ImmediateOrCancel = 2,
        FillOrKill = 3,
        Day = 4,
    }
}