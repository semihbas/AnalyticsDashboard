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
        public async Task<IActionResult> GetByFilter(int? commodityId, int? tradingModelId)
        {
            return Ok(await _tradeService.Get(commodityId, tradingModelId));
        }

        [HttpGet("GetChartSourceByCommodity")]
        public async Task<IActionResult> GetChartSourceByCommodity(int commodityId)
        {
            return Ok(await _tradeService.Get(commodityId));

        }

        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate(int commodityId)
        {
            var res = await _tradeService.Get(DateTime.Now.AddYears(-2));

            return Ok(res); ;
        }


    }
}
