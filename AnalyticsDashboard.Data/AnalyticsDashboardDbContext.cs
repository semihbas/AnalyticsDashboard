using System;
using AnalyticsDashboard.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data
{
    public class AnalyticsDashboardDbContext : DbContext, IAnalyticsDashboardDbContext
    {
        public AnalyticsDashboardDbContext(DbContextOptions<AnalyticsDashboardDbContext> options)
         : base(options)
        {
        }
        public DbSet<Commodity> Commodities { get; set; }

    }
}
