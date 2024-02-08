using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.API.Models.Requests.Order;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.API.Models.Responses.Basket;
using ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        MapFromRequestToQueriesOrCommands();
        MapFromDtoToResponse();
    }

    private void MapFromRequestToQueriesOrCommands()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<BasketLineRequest, BasketLineDto>();
        CreateMap<UpdateBasketLineRequest, BasketLineDto>();

        CreateMap<CreateOrderRequest, CreateOrderCommand>();
        CreateMap<FilterProductsRequest, GetAllProductsQuery>();
        CreateMap<JsonPatchDocument<UpdateOrderRequest>, JsonPatchDocument<PartialUpdateOrderRequest>>();
        CreateMap<Operation<UpdateOrderRequest>, Operation<PartialUpdateOrderRequest>>();
    }

    private void MapFromDtoToResponse()
    {
        CreateMap<ProductDto, ProductResponse>();
        CreateMap<BasketDto, BasketResponse>()
            .ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.Items));

        CreateMap<BasketLineDto, BasketLineResponse>();

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
