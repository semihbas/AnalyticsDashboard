using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Trade>> Get(int commodityId)
        {
            return await _entity
              .Where(x => x.CommodityId == commodityId)
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();

        }

        public async Task<IEnumerable<Trade>> Get(DateTime fromDate)
        {
            return await _entity
              .Where(x => x.Date >= fromDate)
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();

        }


        public async Task<IEnumerable<Trade>> Get(int? commodityId, int? tradingModelId)
        {
            var query = _entity.AsQueryable();

            if (commodityId != null)
            {
                query.Where(x => x.CommodityId == commodityId);
            }

            if (tradingModelId != null)
            {
                query.Where(x => x.TradingModelId == tradingModelId);
            }

            return await query
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();
        }
    }

}
