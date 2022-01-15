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
    public class TradingModelControllerTests
    {
        private Mock<ITradingModelService> _mockService = new Mock<ITradingModelService>();
        private Mock<ILogger<TradingModelController>> _mockLogger = new Mock<ILogger<TradingModelController>>();
        private TradingModelController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockService = new Mock<ITradingModelService>();
            _mockLogger = new Mock<ILogger<TradingModelController>>();
            _controller = new TradingModelController(_mockLogger.Object, _mockService.Object);
        }

        [TestMethod]
        public async Task Get_Should_Return_Valid_ResponseAsync()
        {
            _mockService.Setup(x => x.GetAll()).ReturnsAsync(new List<TradingModelResponse>());

            var result = await _controller.Get() as OkObjectResult;

            _mockService.Verify(mock => mock.GetAll(), Times.Once());
            Assert.AreEqual(((int)HttpStatusCode.OK), result.StatusCode);
        }

    }
}
