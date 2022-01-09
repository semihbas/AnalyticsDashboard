using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnalyticsDashboard.Api.Controllers

{ 
    [Route("api/[controller]")]
    public class TradingModelController : Controller
    {

        private readonly ILogger<TradingModelController> _logger;

        public TradingModelController(ILogger<TradingModelController> logger)
        {
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
