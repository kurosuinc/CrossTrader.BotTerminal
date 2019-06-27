using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using CrossTrader.BotClient;

namespace CrossTrader.BotKit
{
    public class BotBase : IBot
    {
        #region Properties

        public CrossTraderClient Client { get; set; }
        public Dictionary<string, int> InstrumentIds { get; set; }
        
        #endregion

        public BotBase(string host, ushort port)
        {
            Client = new CrossTraderClient()
            {
                Host = host,
                Port = port
            };
        }

        #region Init

        public async Task Init()
        {
            var instruments = await Client.GetInstrumentsAsync();
            InstrumentIds = instruments.ToDictionary(i => i.Name, i => i.Id);
            await OnInitAsync();
        }

        #endregion

        #region DeInit

        public async Task DeInit()
        {
            Client.Dispose();
            await OnDeinitAsync();
        }

        #endregion

        #region EventHandlers

        public int GetInstrumentId(string instrumentName)
        {
            throw new NotImplementedException();
        }

        public Task OnBackTestFinishedAsync(object tradingReport)
        {
            throw new NotImplementedException();
        }

        public Task OnBarFixedAsync(string instrumentName, TimeSpan timeFrame, double open, double high, double low, double close)
        {
            throw new NotImplementedException();
        }

        public Task OnDeinitAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnExecutionReceivedAsync(string instrumentName, Execution execution)
        {
            throw new NotImplementedException();
        }

        public Task OnInitAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnOrdersChanged(string instrumentName, IReadOnlyCollection<OrderParameter> orders)
        {
            throw new NotImplementedException();
        }

        public Task OnTickerReceivedAsync(string instrumentName, Ticker ticker)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
