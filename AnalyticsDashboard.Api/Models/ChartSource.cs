using System;
using System.Collections.Generic;

namespace AnalyticsDashboard.Api.Models
{
    public class ChartSource
    {
        public string Name { get; set; }
        public List<Series> Series { get; set; }
    }
}
