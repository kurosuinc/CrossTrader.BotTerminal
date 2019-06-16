using System;
using System.Threading.Tasks;
using CrossTrader.BotClient;
using System.Linq;

namespace CrossTrader.InagoTakerBotExample
{
    /// <summary>
    /// BitMEX が bitFlyer に先行した動きをすると仮定し、BitMEX の成行ボリューム監視により bitFlyer でトレードを行う Bot です
    /// </summary>
    public class Bot
    {
        #region Properties

        private CrossTraderClient Client { get; }
        private int Spread { get; set; } 

        #endregion

        #region Lock objects

        private object _ConsoleLock = new object();

        #endregion

        public Bot(CrossTraderClient client)
            => Client = client;

        public async Task RunAsync()
        {
            Client.ExecutionsReceived += Client_ExecutionsReceived;
            Client.TickerReceived += Client_TickerReceived;

            var instruments = await Client.GetInstrumentsAsync();

            var mex = instruments.FirstOrDefault(ins =>
                ins.Name == "bitmex" &&
                ins.CanSubscribeExecutions == true);

            var bf = instruments.FirstOrDefault(ins =>
                ins.Name == "bitflyer" &&
                //ins.CanSubscribeOrders == true &&
                //ins.CanSubscribePositions == true &&
                ins.CanSubscribeTicker == true &&
                ins.IsOrderSupported == true);

            if (mex == null)
            {
                Console.WriteLine("Couldn't find BitMEX instrument.");
                return;
            }

            if (bf == null)
            {
                Console.WriteLine("Couldn't find bitFlyer instrument.");
                return;
            }

            Client.SubscribeExecutions(mex.Id);
            Client.SubscribeTicker(bf.Id);
            while (true)
            {
                await Task.Delay(1000);
            }
        }

        private void Client_TickerReceived(object sender, ReceivedEventArgs<Ticker> e)
        {
            var ticker = e.Data;
            var spread = (int)(ticker.BestAsk - ticker.BestBid);
            Spread = spread;
            Console.WriteLine($"bitFlyer spread updated: {spread}");
        }

        private void Client_ExecutionsReceived(object sender, CollectionReceivedEventArgs<Execution> e)
        {
            var executions = e.Data;
            lock (_ConsoleLock)
            {
                Console.WriteLine($"BitMEX executions received: {executions.Count()} executions.");
                foreach (var ex in executions)
                {
                    Console.Write($"  => {ex.CreatedAt} ");
                    Console.ForegroundColor = ex.Side == OrderSide.Buy ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(ex.Side.ToString().ToUpper().PadRight(4));
                    Console.ResetColor();
                    Console.Write($" {ex.Size:F3}BTC at price ${ex.Price:F1}.");
                    Console.Write(Environment.NewLine);
                }
                // TODO: Create market order if executed volume is bigger than threshold.
            }
        }
    }
}
