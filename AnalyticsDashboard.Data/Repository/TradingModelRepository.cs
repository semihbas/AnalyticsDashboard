using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data.Repository
{
    public class TradingModelRepository : Repository<TradingModel>, ITradingModelRepository
    {
        private readonly DbSet<TradingModel> _entity;
        public TradingModelRepository(AnalyticsDashboardDbContext context) : base(context)
        {
            _entity = context.Set<TradingModel>();
        }

        public async Task<List<TradingModel>> GetAll()
        {
            return await _entity.ToListAsync();
        }
    }
}
