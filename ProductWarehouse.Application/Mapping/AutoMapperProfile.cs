using AutoMapper;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UpdateOrderCommand, Order>();

        CreateMap<Brand, BrandDto>().ReverseMap();
        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<Size, SizeDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
        CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
        CreateMap<ProductSize, ProductSizeDto>().ReverseMap();
        
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes.Select(p => p.Size.Name).Distinct().ToList()))
            .ReverseMap();

        CreateMap<IReadOnlyList<Product>, ProductsFilterDto>()
            .ForMember(dest => dest.MinPrice, opt => opt.MapFrom(src => src.Min(p => p.Price)))
            .ForMember(dest => dest.MaxPrice, opt => opt.MapFrom(src => src.Max(p => p.Price)))
             .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src
                     .SelectMany(p => p.ProductSizes)
                     .Where(ps => ps.Size != null)
                     .SelectMany(ps => ps.Size.Name)
                     .Distinct()
                     .ToList()
             ))
            .ForMember(dest => dest.CommonWords, opt => opt.MapFrom(src => src.FindMostCommonWords()))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));

    }
}
