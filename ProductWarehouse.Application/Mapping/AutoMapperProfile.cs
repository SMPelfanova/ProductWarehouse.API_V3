using AutoMapper;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<IEnumerable<Product>, ProductsFilterDto>()
            .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.Min(p => p.Price)))
            .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.Max(p => p.Price)))
            //.ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.SelectMany(p => p.ProductSizes).Distinct()))
            .ForMember(dest => dest.CommonWords, opt => opt.MapFrom(src => src.FindMostCommonWords()))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));
    }
}
