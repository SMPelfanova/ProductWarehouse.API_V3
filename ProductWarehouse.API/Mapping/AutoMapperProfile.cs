using AutoMapper;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, ProductResponse>();
        CreateMap<FilterProductsRequest, ProductsQuery>();
        CreateMap<ProductsFilterDto, ProductFilterResponse>()
           .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
           .ForMember(dest => dest.Filter, opt => opt.MapFrom(src => src));

        CreateMap<ProductsFilterDto, FilterResponse>()
           .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.MinPrice))
           .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.MaxPrice))
           .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.Sizes))
           .ForMember(dest => dest.CommonWords, opt => opt.MapFrom(src => src.CommonWords));
    }
}
