using System;
using System.Collections.Generic;

namespace AnalyticsDashboard.Api.Models
{
    public class CommodityTradingModel
    {
        public List<TradingModelTrade> TradingModels { get; set; }
    }

    public class TradingModelTrade
    {
        public List<TradeResponse> Trades { get; set; }
    }
}

