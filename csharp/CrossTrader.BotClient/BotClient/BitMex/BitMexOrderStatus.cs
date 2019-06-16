namespace CrossTrader.BotClient.BitMex
{
    public enum BitMexOrderStatus
    {
        None = 0,
        New = 1,
        PartiallyFilled = 2,
        Filled = 3,
        Canceled = 4,
        Rejected = 5,
        Expired = 6,
    }
}