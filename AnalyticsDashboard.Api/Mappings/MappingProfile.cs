using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Data.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsDashboard.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trade, TradeResponse>().ReverseMap();
            CreateMap<TradingModel, TradingModelResponse>().ReverseMap();
            CreateMap<Commodity, CommodityResponse>().ReverseMap();
        }
    }
}