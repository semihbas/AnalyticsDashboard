using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Mappings;
using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Api.Service;
using AnalyticsDashboard.Data;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnalyticsDashboard.Api.UnitTests.Services
{
    [TestClass]
    public class TradeServiceTests
    {
        private TradeService _service;
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private Mock<ITradeRepository> _mockRepository = new Mock<ITradeRepository>();
        private Mock<AnalyticsDashboardDbContext> _mockContext = new Mock<AnalyticsDashboardDbContext>();
        private Mock<DbSet<Trade>> _mockTrade = new Mock<DbSet<Trade>>();

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository.Setup(x => x.Get(It.IsAny<int>()));
            _mockContext.Setup(x => x.Trades).Returns(_mockTrade.Object);

            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _service = new TradeService(mapper, _mockRepository.Object);

        }

        [TestMethod]
        public async Task GetAll_Returns_Valid_ResponeAsync()
        {
            var chartSource = new List<ChartSource>() { new ChartSource()
            {
                Name = "Test",
                Series = new List<Series>()
                {
                    new Series()
                    {
                        Name= "test",
                        Value= 5
                    }
                }
            }};


            var trades = new List<Trade>() { new Trade(){
                CommodityId=5,
                Contract = "Test",
                PnLDaily = 5,
                TradingModel = new TradingModel()
                {
                    Id= 5,
                    Name = "test"
                }
            } };


            _mockRepository.Setup(x => x.Get(5)).ReturnsAsync(trades);

            var result = await _service.Get(5);

            _mockRepository.Verify(mock => mock.Get(It.IsAny<int>()), Times.Once());
            Assert.AreEqual(result.Count, chartSource.Count);
        }
    }
}
