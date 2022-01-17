using System;
using System.Collections.Generic;

namespace AnalyticsDashboard.Api.Models
{

    public class TradingModelTrades
    {
        public TradingModelResponse TradingModel { get; set; }
        public List<TradeResponse> Trades { get; set; }
    }
}