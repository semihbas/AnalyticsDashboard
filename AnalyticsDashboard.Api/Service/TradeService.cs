using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;

namespace AnalyticsDashboard.Api.Service
{
    public class TradeService :ITradeService
    {
        private readonly ITradeRepository _TradeRepository;
        public TradeService(ITradeRepository TradeRepository)
        {
            _TradeRepository = TradeRepository;
        }

        public async Task<List<Trade>> Get(int skip, int take)
        {
            return await _TradeRepository.Get(skip, take);

        }
    }
}
