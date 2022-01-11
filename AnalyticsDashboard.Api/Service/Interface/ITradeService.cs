using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Model;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradeService
    {
        Task<IEnumerable<ChartSource>> Get(int commodityId);
        Task<IEnumerable<Trade>> Get(int skip, int take);
        Task<IEnumerable<Trade>> Get(int skip, int take, int? commodityId, int? tradingModelId);
    }
}
