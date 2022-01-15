using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradeService
    {
        Task<List<ChartSource>> Get(int commodityId);
        Task<List<TradeResponse>> Get(int? commodityId, int? tradingModelId);
        Task<List<ChartSource>> Get(DateTime fromDate);
    }
}
