﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service.Interface;
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
        [HttpGet("GetByFilter")]
        public async Task<IEnumerable<TradeResponse>> GetByFilter(int? commodityId, int? tradingModelId)
        {
            return await _tradeService.Get(commodityId, tradingModelId);
        }

        [HttpGet("GetChartSourceByCommodity")]
        public async Task<IEnumerable<ChartSource>> GetChartSourceByCommodity(int commodityId)
        {
          return await _tradeService.Get(commodityId);
           
        }

    }
}
