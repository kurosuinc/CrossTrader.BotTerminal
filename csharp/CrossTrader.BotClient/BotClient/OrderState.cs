namespace CrossTrader.BotClient
{
    public enum OrderState
    {
        None,
        Requesting,
        Failed,
        Active,
        Completed,
        Canceling,
        Canceled,
        Expired
    }
}
