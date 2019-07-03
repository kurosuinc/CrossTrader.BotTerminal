namespace CrossTrader.BotClient.BitMex
{
    public enum BitMexOrderType
    {
        None = 0,
        Market = 1,
        Limit = 2,
        Stop = 3,
        StopLimit = 4,
        MarketIfTouched = 5,
        LimitIfTouched = 6,
        MarketWithLeftOverAsLimit = 7,
    }
}