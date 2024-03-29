using System;
using Google.Protobuf.WellKnownTypes;

namespace CrossTrader.BotClient
{
    internal static class DateTimeHelper
    {
        private static readonly DateTimeOffset _Epoch = new(1970, 1, 1, 0, 0, 0, default);

        public static DateTimeOffset? ToClientValue(this Timestamp v)
        {
            var dto = v?.ToDateTimeOffset();
            return (dto == null || dto == _Epoch) ? (DateTimeOffset?)null : dto;
        }
    }
}