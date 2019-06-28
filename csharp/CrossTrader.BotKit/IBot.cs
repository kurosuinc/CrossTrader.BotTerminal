using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrossTrader.BotClient;

namespace CrossTrader.BotKit
{
    public interface IBot
    {
        CrossTraderClient Client { get; set; }
        Dictionary<string, int> InstrumentIds { get; set; }
        int GetInstrumentId(string instrumentName);

        /// <summary>
        /// bot の処理開始時に1度だけ呼ばれます
        /// </summary>
        /// <returns></returns>
        Task OnInitAsync();

        /// <summary>
        /// bot の処理終了時に1度だけ呼ばれます
        /// </summary>
        /// <returns></returns>
        Task OnDeinitAsync();

        /// <summary>
        /// 新しい Ticker を受信した際に呼ばれます
        /// </summary>
        /// <param name="instrumentName">銘柄名</param>
        /// <param name="price"></param>
        /// <returns></returns>
        Task OnTickerReceivedAsync(string instrumentName, Ticker ticker);

        /// <summary>
        /// 注文情報が変化した際に呼ばれます
        /// </summary>
        /// <param name="instrumentName"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        Task OnOrdersChanged(string instrumentName, IReadOnlyCollection<Order> orders); // TODO: OrderParameter -> Order

        /// <summary>
        /// ポジション情報が変化した際に呼ばれます
        /// </summary>
        /// <param name="instrumentName"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        //Task OnPositionsChanged(string instrumentName, IReadOnlyCollection<Position> orders);

        /// <summary>
        /// 新しい約定が発生した際に呼ばれます
        /// </summary>
        /// <param name="instrumentName">銘柄名</param>
        /// <param name=""></param>
        /// <returns></returns>
        Task OnExecutionReceivedAsync(string instrumentName, Execution execution);

        /// <summary>
        /// 新しい足が確定した際に呼ばれます
        /// </summary>
        /// <param name="instrumentName">銘柄名</param>
        /// <param name="timeFrame">バーのタイムフレームです</param>
        /// <param name="open">始値</param>
        /// <param name="high">高値</param>
        /// <param name="low">安値</param>
        /// <param name="close">終値</param>
        /// <returns></returns>
        Task OnBarFixedAsync(string instrumentName, TimeSpan timeFrame, double open, double high, double low, double close);

        /// <summary>
        /// バックテストが完了した際に呼ばれます
        /// </summary>
        /// <param name="tradingReport">トレード結果のレポート</param>
        /// <returns></returns>
        Task OnBackTestFinishedAsync(object tradingReport);
    }
}
