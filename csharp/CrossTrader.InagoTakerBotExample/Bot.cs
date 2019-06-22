using System;
using System.Threading.Tasks;
using CrossTrader.BotClient;
using System.Linq;
using System.Collections.ObjectModel;
using Grpc.Core;

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

        private Instrument BitMexInstrument { get; set; }
        private Instrument BitFlyerInstrument { get; set; }

        #endregion

        #region Lock objects

        private object _ConsoleLock = new object();

        #endregion

        public Bot(CrossTraderClient client)
            => Client = client;

        public async Task RunAsync()
        {
            var instruments = await Client.GetInstrumentsAsync();

            BitMexInstrument = instruments.FirstOrDefault(ins =>
                ins.Name == "bitmex" &&
                ins.CanSubscribeExecutions == true);

            BitFlyerInstrument = instruments.FirstOrDefault(ins =>
                ins.Name == "bitflyer" &&
                //ins.CanSubscribeOrders == true &&
                //ins.CanSubscribePositions == true &&
                ins.CanSubscribeTicker == true &&
                ins.IsOrderSupported == true);

            if (BitMexInstrument == null)
            {
                Console.WriteLine("Couldn't find BitMEX instrument.");
                return;
            }

            if (BitFlyerInstrument == null)
            {
                Console.WriteLine("Couldn't find bitFlyer instrument.");
                return;
            }

            Client.ExecutionsReceived += this.Client_ExecutionsReceived;
            Client.TickerReceived += this.Client_TickerReceived;

            Client.SubscribeExecutions(BitMexInstrument.Id);
            Client.SubscribeTicker(BitFlyerInstrument.Id);
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
            => HandleExecutionsAsync(e.Data).ConfigureAwait(false);

        private async Task HandleExecutionsAsync(ReadOnlyCollection<Execution> executions)
        {
            Console.WriteLine($"BitMEX executions received: {executions.Count()} executions.");

            var sizeToOrder = 0.01;

            // executions grouped by size.
            var groups = executions.GroupBy(ex => ex.Side)
                .OrderByDescending(exs => exs.Sum(ex => ex.Size));
            // executions group which has bigger volume
            var group = groups.First();

            lock (_ConsoleLock)
            {
                foreach (var exs in groups)
                {
                    var ex = exs.First();
                    Console.Write($"  => {ex.CreatedAt} ");
                    Console.ForegroundColor = ex.Side == OrderSide.Buy ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(ex.Side.ToString().ToUpper().PadRight(4));
                    Console.ResetColor();
                    Console.Write($" {exs.Sum(it => it.Size):F3}BTC.");
                    Console.Write(Environment.NewLine);
                }
            }

            var size = group.Sum(ex => ex.Size);
            var side = group.First().Side;
            if (size > 1)
            {
                lock (_ConsoleLock)
                {
                    Console.Write($"    => ");
                    Console.ForegroundColor = side == OrderSide.Buy ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(side.ToString().ToUpper().PadRight(4));
                    Console.ResetColor();
                    Console.Write($" {sizeToOrder}BTC.");
                }

                try
                {
                    var res = await Client.LimitOrderAsync(BitFlyerInstrument.Id, OrderSide.Sell, sizeToOrder, 1350000).ConfigureAwait(false);
                    Console.WriteLine($"    => {res.CreatedAt} '{res.OrderId}', '{res.RequestId}'");
                } catch(RpcException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
