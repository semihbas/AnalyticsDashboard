using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnalyticsDashboard.Api.Controllers
{
    [Route("api/[controller]")]
        public class TradeController : Controller
        {

            private readonly ILogger<TradeController> _logger;
        private readonly ITradeService _tradeService;

        public TradeController(ILogger<TradeController> logger, ITradeService tradeService)
        {
                _logger = logger;
        _tradeService = tradeService;
        }


        [HttpGet]
            public async Task<IEnumerable<Trade>> Get(int skip=1, int take=250)
            {
            return await _tradeService.Get(skip, take);
            }


        [HttpGet("GetByFilter")]
        public IEnumerable<string> GetByFilter(int? commodityId, int? tradingModelId)
        {
            return new string[] { "value1", "value2" };
        }

    }
}
