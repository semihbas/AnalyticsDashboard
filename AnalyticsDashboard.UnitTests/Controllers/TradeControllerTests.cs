using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Controllers;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnalyticsDashboard.Api.UnitTests.Controllers
{
    [TestClass]
    public class TradeControllerTests
    {
        private Mock<ITradeService> _mockService = new Mock<ITradeService>();
        private Mock<ILogger<TradeController>> _mockLogger = new Mock<ILogger<TradeController>>();
        private TradeController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockService = new Mock<ITradeService>();
            _mockLogger = new Mock<ILogger<TradeController>>();
            _controller = new TradeController(_mockLogger.Object, _mockService.Object);
        }

        [TestMethod]
        public async Task GetChartSourceByCommodity_Should_Return_Valid_ResponseAsync()
        {
            _mockService.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(new List<ChartSource>());

            var result = await _controller.GetChartSourceByCommodity(It.IsAny<int>()) as OkObjectResult;

            _mockService.Verify(mock => mock.Get(It.IsAny<int>()), Times.Once());

            Assert.AreEqual(((int)HttpStatusCode.OK), result.StatusCode);
        }

        [TestMethod]
        public async Task GetByFilter_Should_Return_Valid_ResponseAsync()
        {
            _mockService.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(new List<ChartSource>());

            var result = await _controller.GetByFilter(It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>()) as OkObjectResult;

            _mockService.Verify(mock => mock.Get(It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());

            Assert.AreEqual(((int)HttpStatusCode.OK), result.StatusCode);
        }

        [TestMethod]
        public async Task GetByDateAndCommodity_Should_Return_Valid_ResponseAsync()
        {
            _mockService.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(new List<ChartSource>());

            var result = await _controller.GetByDateAndCommodity(It.IsAny<DateTime>(), It.IsAny<int>()) as OkObjectResult;

            _mockService.Verify(mock => mock.Get(It.IsAny<DateTime>(), It.IsAny<int>()), Times.Once());

            Assert.AreEqual(((int)HttpStatusCode.OK), result.StatusCode);
        }

    }
}
