using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> Get(int skip, int take);
        Task<IEnumerable<Trade>> Get(int skip, int take, int? commodityId, int? tradingModelId);
    }
}
