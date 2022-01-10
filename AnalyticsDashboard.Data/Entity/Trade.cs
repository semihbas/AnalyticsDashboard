using System;
namespace AnalyticsDashboard.Data.Entity
{
    public class Trade : IEntity
    {
        public int Id { get; set; }

        public int TradingModelId { get; set; }

        public int CommodityId { get; set; }

        public DateTime Date { get; set; }

        public string Contract { get; set; }

        public decimal Price { get; set; }

        public int Position { get; set; }

        public int NewTradeAction { get; set; }

        public decimal PnLDaily { get; set; }

        public virtual TradingModel TradingModel { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
