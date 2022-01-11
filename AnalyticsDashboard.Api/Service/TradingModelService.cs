﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data.Entity;
using AnalyticsDashboard.Data.Repository.Interface;

namespace AnalyticsDashboard.Api.Service
{
    public class TradingModelService : ITradingModelService
    {
        private readonly ITradingModelRepository _tradingModelRepository;

        public TradingModelService( ITradingModelRepository tradingModelRepository)
        {
            _tradingModelRepository = tradingModelRepository;
        }

        public async Task<IEnumerable<TradingModel>> GetAll()
        {
            return await _tradingModelRepository.GetAll();
        }
    }
}