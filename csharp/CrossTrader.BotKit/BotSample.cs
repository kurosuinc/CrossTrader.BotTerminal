using System.ComponentModel;

namespace CrossTrader.BotKit
{
    /// <summary>
    /// 一定以上の約定を検知でいなごトレードを行うBotです
    /// </summary>
    public class BotSample : BotBase
    {
        [Category("全般設定"), DisplayName("トレード銘柄"), Description("トレードを行う対象の銘柄")]
        public string TradingInstrument { get; set; }
        [Category("いなご検知設定"), DisplayName("監視銘柄"), Description("発注の条件となるボリューム検知の対象銘柄")]
        public string InagoTargetInstrument { get; set; }
        [Category("いなご検知設定"), DisplayName("発注閾値"), Description("発注の条件となるボリューム検知")]
        public double InagoVolumeThreshold { get; set; }
        [Category("エントリー設定"), DisplayName("発注サイズ"), Description("発注時の数量を指定します")]
        public double OrderSize { get; set; }
        [Category("イグジット設定"), DisplayName("TP値幅"), Description("指定以上の利益値幅になった際に利確（TakeProfit）します")]
        public double TakeProfitThreshold { get; set; }
        [Category("イグジット設定"), DisplayName("SL値幅"), Description("指定以上の損益値幅になった際に損切（StopLoss）します")]
        public double StopLossThreshold { get; set; }
    }
}
