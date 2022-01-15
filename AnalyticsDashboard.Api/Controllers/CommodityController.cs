using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnalyticsDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    public class CommodityController : Controller
    {

        private readonly ILogger<CommodityController> _logger;
        private readonly ICommodityService _commodityService;

        public CommodityController(ILogger<CommodityController> logger, ICommodityService commodityService)
        {
            _logger = logger;
            _commodityService = commodityService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._commodityService.GetAll();

            return Ok(result);
        }
    }
}
