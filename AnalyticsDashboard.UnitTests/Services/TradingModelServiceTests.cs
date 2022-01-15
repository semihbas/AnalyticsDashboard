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
    public class TradingModelServiceTests
    {
        private TradingModelService _service;
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private Mock<ITradingModelRepository> _mockRepository = new Mock<ITradingModelRepository>();
        private Mock<AnalyticsDashboardDbContext> _mockContext = new Mock<AnalyticsDashboardDbContext>();
        private Mock<DbSet<TradingModel>> _mockTradingModel = new Mock<DbSet<TradingModel>>();

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository.Setup(x => x.GetAll());
            _mockContext.Setup(x => x.TradingModels).Returns(_mockTradingModel.Object);

            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _service = new TradingModelService(mapper, _mockRepository.Object);

        }

        [TestMethod]
        public async Task GetAll_Returns_Valid_ResponeAsync()
        {
            var commodities = new List<TradingModel>() { new TradingModel()
            {
                Id = 5,
                Name = "test"
            }};

            _mockRepository.Setup(x => x.GetAll()).ReturnsAsync(commodities);
            var result = await _service.GetAll();

            _mockRepository.Verify(mock => mock.GetAll(), Times.Once());
            Assert.AreEqual(result.Count, commodities.Count);
        }
    }
}
