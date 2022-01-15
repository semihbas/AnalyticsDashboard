using System;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Controllers;
using AnalyticsDashboard.Api.Service.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnalyticsDashboard.Api.UnitTests.Controllers
{
    [TestClass]
    public class CommodityControllerTests
    {
        [TestMethod]
        public async Task Get_Should_Return_Valid_ResponseAsync()
        {
            var mockService = new Mock<ICommodityService>();
            var mockLogger = new Mock<ILogger<CommodityController>>();
            var controller = new CommodityController(mockLogger.Object, mockService.Object);

            var result = await controller.Get();

            Assert.IsNotNull(result);

        }
    }
}
