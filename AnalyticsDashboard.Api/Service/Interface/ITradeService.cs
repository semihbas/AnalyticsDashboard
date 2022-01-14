using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Model;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradeService
    {
        Task<IEnumerable<ChartSource>> Get(int commodityId);
        Task<IEnumerable<TradeResponse>> Get(int? commodityId, int? tradingModelId);
    }
}
