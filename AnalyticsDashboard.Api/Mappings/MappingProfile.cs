using AnalyticsDashboard.Api.Models;
using AnalyticsDashboard.Data.Entity;
using AutoMapper;

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