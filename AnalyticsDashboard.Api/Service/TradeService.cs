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

        public async Task<List<TradeResponse>> Get(DateTime fromDate, int? commodityId, int? tradingModelId)
        {
            var model = await _tradeRepository.Get(fromDate, commodityId, tradingModelId);

            return _mapper.Map<List<TradeResponse>>(model);
        }


        public async Task<List<ChartSource>> Get(int commodityId)
        {
            var result = await _tradeRepository.Get(commodityId);

            var groupedResult = result.GroupBy(
                p => p.TradingModel.Name,
                p => new Series { Name = p.Date, Value = p.PnLDaily },
                (key, g) => new ChartSource { Name = key, Series = g.ToList() });

            return groupedResult.ToList();
        }


        public async Task<List<TradingModelTrades>> Get(DateTime fromDate, int commodityId)
        {
            var model = await _tradeRepository.Get(fromDate, commodityId, null);
            var result = _mapper.Map<List<TradeResponse>>(model);

            var results = result.GroupBy(
                p => p.TradingModel.Id,
                p => p,
                (key, g) => new TradingModelTrades { TradingModel = new TradingModelResponse() {Id= key, Name=g.FirstOrDefault().TradingModel.Name }, Trades = g.ToList() }).ToList();

            return results;

        }
    }

}
