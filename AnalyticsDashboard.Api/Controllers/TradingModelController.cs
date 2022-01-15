using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnalyticsDashboard.Api.Controllers

{
    [Route("api/[controller]")]
    public class TradingModelController : Controller
    {

        private readonly ILogger<TradingModelController> _logger;
        private readonly ITradingModelService _tradingModelService;

        public TradingModelController(ILogger<TradingModelController> logger, ITradingModelService tradingModelService)
        {
            _logger = logger;
            _tradingModelService = tradingModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _tradingModelService.GetAll());
        }

    }
}
