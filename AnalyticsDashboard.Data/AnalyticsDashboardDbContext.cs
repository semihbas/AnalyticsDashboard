using System;
using AnalyticsDashboard.Data.Configuration;
using AnalyticsDashboard.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Data
{
    public class AnalyticsDashboardDbContext : DbContext
    {
        public AnalyticsDashboardDbContext(DbContextOptions<AnalyticsDashboardDbContext> options)
         : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Commodity> Commodities { get; set; }
        public virtual DbSet<TradingModel> TradingModels { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CommodityConfiguration());
            modelBuilder.ApplyConfiguration(new TradingModelConfiguration());
            modelBuilder.ApplyConfiguration(new TradeConfiguration());
        }
    }
}
