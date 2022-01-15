using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Data.Entity;

namespace AnalyticsDashboard.Api.Service.Interface
{
    public interface ICommodityService
    {
        Task<List<CommodityResponse>> GetAll();
    }
}
