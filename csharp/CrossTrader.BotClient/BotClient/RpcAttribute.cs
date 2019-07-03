using System;

namespace CrossTrader.BotClient
{
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class RpcAttribute : Attribute
    {
        public RpcAttribute(string serviceName) => ServiceName = serviceName;

        public string ServiceName { get; }
    }
}