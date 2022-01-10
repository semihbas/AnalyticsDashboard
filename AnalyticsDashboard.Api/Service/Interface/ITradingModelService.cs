using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ITradingModelService
    {
        Task<IEnumerable<TradingModel>> GetAll();
    }
}
