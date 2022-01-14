using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Data.Repository.Interface
{
    public interface ITradingModelRepository
    {
        Task<IEnumerable<TradingModel>> GetAll();
    }
}
