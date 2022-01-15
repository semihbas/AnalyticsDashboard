using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradeService
    {
        Task<IEnumerable<ChartSource>> Get(int commodityId);
        Task<IEnumerable<TradeResponse>> Get(int? commodityId, int? tradingModelId);
        Task<IEnumerable<ChartSource>> Get(DateTime fromDate);
    }
}
