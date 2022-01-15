using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Repository.Interface;
using AutoMapper;

namespace AnalyticsDashboard.Api.Service
{
    public class TradeService : ITradeService
    {
        private readonly IMapper _mapper;
        private readonly ITradeRepository _tradeRepository;
        public TradeService(IMapper mapper, ITradeRepository tradeRepository)
        {
            _mapper = mapper;
            _tradeRepository = tradeRepository;
        }

        public async Task<IEnumerable<TradeResponse>> Get(int? commodityId, int? tradingModelId)
        {
            var model = await _tradeRepository.Get(commodityId, tradingModelId);

            return _mapper.Map<IEnumerable<TradeResponse>>(model);
        }


        public async Task<IEnumerable<ChartSource>> Get(int commodityId)
        {
            var result = await _tradeRepository.Get(commodityId);

            var groupedResult = result.GroupBy(
                p => p.TradingModel.Name,
                p => new Series { Name = p.Date, Value = p.PnLDaily },
                (key, g) => new ChartSource { Name = key, Series = g.ToList() });

            return groupedResult;
        }


        public async Task<IEnumerable<ChartSource>> Get(DateTime fromDate)
        {
            var result = await _tradeRepository.Get(fromDate);

            var groupedResult = result
                .GroupBy(p => new { Commodity= p.Commodity, TradingModel = p.TradingModel })
                .GroupBy(p =>  p.Key.Commodity);

            return null;
        }
    }
}
