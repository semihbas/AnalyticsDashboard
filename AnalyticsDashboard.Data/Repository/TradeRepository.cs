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

        public async Task<List<Trade>> Get(int commodityId)
        {
            return await _entity
              .Where(x => x.CommodityId == commodityId)
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();

        }

        public async Task<List<Trade>> Get(DateTime fromDate)
        {
            return await _entity
              .Where(x => x.Date >= fromDate)
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();

        }


        public async Task<List<Trade>> Get(DateTime fromDate, int? commodityId, int? tradingModelId)
        {
            var query = _entity.AsNoTracking();

            if (commodityId != null && commodityId != 0)
            {
                query = query.Where(x => x.CommodityId == commodityId);
            }

            if (tradingModelId != null && tradingModelId != 0)
            {
                query = query.Where(x => x.TradingModelId == tradingModelId);
            }

            var result = await query
                .Where(x => x.Date >= fromDate)
              .Include(x => x.TradingModel)
              .Include(x => x.Commodity)
              .OrderBy(x => x.Date)
              .ToListAsync();

            return result;
        }
    }

}
