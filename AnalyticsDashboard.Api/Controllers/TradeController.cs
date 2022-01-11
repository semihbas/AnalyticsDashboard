﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Model;
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
        public async Task<IEnumerable<Trade>> GetByFilter(int skip, int take,int? commodityId, int? tradingModelId)
        {
            return await _tradeService.Get(skip, take,commodityId, tradingModelId);
        }

        [HttpGet("GetChartSourceByCommodity")]
        public async Task<IEnumerable<ChartSource>> GetChartSourceByCommodity(int commodityId)
        {
          return await _tradeService.Get(commodityId);
           
        }

    }
}
