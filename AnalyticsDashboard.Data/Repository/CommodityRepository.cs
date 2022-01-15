using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data.Repository
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        private readonly DbSet<Commodity> _entity;
        public CommodityRepository(AnalyticsDashboardDbContext context) : base(context)
        {
            _entity = context.Set<Commodity>();
        }

        public async Task<List<Commodity>> GetAll()
        {
            return await _entity.ToListAsync();
        }
    }
}
