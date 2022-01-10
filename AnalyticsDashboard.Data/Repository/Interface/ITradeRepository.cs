using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Data.Repository.Interface
{
    public interface ITradeRepository
    {
        Task<List<Trade>> Get(int skip, int take);
        Task<IEnumerable<Trade>> Get(int skip, int take, int? commodityId, int? tradingModelId);
    }
}
