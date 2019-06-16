using System;
using System.Threading.Tasks;
using CrossTrader.BotClient;

namespace CrossTrader.InagoTakerBotExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: Parse host and port from command line args
            var host = "localhost";
            var port = 10666;
            var client = new CrossTraderClient()
            {
                Host = host,
                Port = (ushort)port
            };
            await (new Bot(client)).RunAsync();
        }
    }
}
