using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using AutoMapper;

namespace AnalyticsDashboard.Api.Service
{
    public class CommodityService : ICommodityService
    {
        private readonly IMapper _mapper;
        private readonly ICommodityRepository _commodityRepository;
        public CommodityService(IMapper mapper, ICommodityRepository commodityRepository)
        {
            _mapper = mapper;
            _commodityRepository = commodityRepository;
        }

        public async Task<IEnumerable<CommodityResponse>> GetAll()
        {
            var model = await _commodityRepository.GetAll();

            return _mapper.Map<IEnumerable<CommodityResponse>>(model);
        }
    }
}
