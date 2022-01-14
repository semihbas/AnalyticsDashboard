using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using AutoMapper;

namespace AnalyticsDashboard.Api.Service
{
    public class TradingModelService : ITradingModelService
    {
        private readonly IMapper _mapper;
        private readonly ITradingModelRepository _tradingModelRepository;

        public TradingModelService(IMapper mapper, ITradingModelRepository tradingModelRepository)
        {
            _mapper = mapper;
            _tradingModelRepository = tradingModelRepository;
        }

        public async Task<IEnumerable<TradingModelResponse>> GetAll()
        {
            var model = await _tradingModelRepository.GetAll();

            return _mapper.Map<IEnumerable<TradingModelResponse>>(model);
        }
    }
}
