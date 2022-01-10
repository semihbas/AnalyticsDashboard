using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data.Repository
{

        public class TradeRepository : Repository<Trade>, ITradeRepository
        {
            private readonly DbSet<Trade> _entity;
            public TradeRepository(AnalyticsDashboardDbContext context) : base(context)
            {
                _entity = context.Set<Trade>();
            }

            public async Task<List<Trade>> Get(int skip, int take)
            {
                return await _entity
                .Include(x=>x.TradingModel)
                .Include (x=>x.Commodity)
                .OrderByDescending(x=>x.Id)
                .Skip((skip-1)* take)
                .Take(take)
                .ToListAsync();
            }
        }
    
}
