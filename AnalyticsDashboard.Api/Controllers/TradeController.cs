using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetByFilter(DateTime fromDate, int? commodityId, int? tradingModelId)
        {
            return Ok(await _tradeService.Get(fromDate, commodityId, tradingModelId));
        }

        [HttpGet("GetChartSourceByCommodity")]
        public async Task<IActionResult> GetChartSourceByCommodity(int commodityId)
        {
            return Ok(await _tradeService.Get(commodityId));
        }

        [HttpGet("GetByDateAndCommodity")]
        public async Task<IActionResult> GetByDateAndCommodity(DateTime fromDate, int commodityId)
        {
            return Ok(await _tradeService.Get(fromDate, commodityId)); 
        }

    }
}
