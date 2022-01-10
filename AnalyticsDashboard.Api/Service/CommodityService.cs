using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;

namespace AnalyticsDashboard.Api.Service
{
    public class CommodityService :ICommodityService
    {
        private readonly ICommodityRepository _commodityRepository;
        public CommodityService(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }

        public async Task<List<Commodity>> GetAll()
        {
            return await _commodityRepository.GetAll();

        }
    }
}
