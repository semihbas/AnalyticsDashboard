using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Model;
using AnalyticsDashboard.Data.Repository.Interface;

namespace AnalyticsDashboard.Api.Service
{
    public class TradeService :ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task<IEnumerable<Trade>> Get(int skip, int take)
        {
            return await _tradeRepository.Get(skip, take);

        }

        public async Task<IEnumerable<Trade>> Get(int skip, int take, int? commodityId, int? tradingModelId)
        {
            return await _tradeRepository.Get(skip, take,commodityId, tradingModelId );
        }


        public async Task<IEnumerable<ChartSource>> Get(int commodityId)
        {
            var res= await _tradeRepository.Get(commodityId);

            return res.GroupBy(
                p => p.TradingModel.Name,
                p => new Series { Name = p.Date, Value= p.PnLDaily },
                (key, g) => new ChartSource { Name = key, Series = g.ToList() });


        }
    }
}
