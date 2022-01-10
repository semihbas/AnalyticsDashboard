using System;
namespace AnalyticsDashboard.Data.Entity
{
    public class Commodity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
