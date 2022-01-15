using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Data.Repository.Interface
{
    public interface ITradeRepository
    {
        Task<List<Trade>> Get(int commodityId);
        Task<List<Trade>> Get(DateTime fromDate);
        Task<List<Trade>> Get(int? commodityId, int? tradingModelId);
    }
}
