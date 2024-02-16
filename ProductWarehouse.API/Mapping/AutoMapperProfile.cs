using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.API.Models.Requests.Order;
using ProductWarehouse.API.Models.Requests.Product.Group;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.API.Models.Responses.Basket;
using ProductWarehouse.API.Models.Responses.Group;
using ProductWarehouse.API.Models.Responses.Order;
using ProductWarehouse.API.Models.Responses.Size;
using ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Mapping;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		MapFromRequestToQueries();
		MapFromRequestToCommands();
		MapFromDtoToResponse();
	}

	private void MapFromRequestToQueries()
	{
		CreateMap<AddBasketLineRequest, AddBasketLineCommand>();
		CreateMap<UpdateBasketLineRequest, UpdateBasketLineCommand>();

		CreateMap<CreateProductRequest, CreateProductCommand>()
			.ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.Sizes))
			.ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups));

		CreateMap<UpdateProductRequest, UpdateProductCommand>();
		CreateMap<CreateProductSizeRequest, CreateProductSizeCommand>()
			.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

		CreateMap<CreateProductGroupRequest, CreateProductGroupCommand>()
			.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

		CreateMap<OrderLineRequest, OrderLineDto>();
		CreateMap<CreateOrderRequest, CreateOrderCommand>()
			.ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines));

		CreateMap<JsonPatchDocument<UpdateOrderRequest>, JsonPatchDocument<PartialUpdateOrderCommandRequest>>();
		CreateMap<Operation<UpdateOrderRequest>, Operation<PartialUpdateOrderCommandRequest>>();
	}

	private void MapFromRequestToCommands()
	{
		CreateMap<FilterProductsRequest, GetAllProductsQuery>();
	}

	private void MapFromDtoToResponse()
	{
		CreateMap<SizeDto, SizeResponse>();
		CreateMap<GroupDto, GroupResponse>();
		CreateMap<BasketDto, BasketResponse>()
			.ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<BasketLineDto, BasketLineResponse>();
		CreateMap<BasketDto, BasketResponse>()
			.ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<OrderLineDto, OrderLineResponse>();

		CreateMap<OrderDto, OrderStatusResponse>()
			.ForMember(dest => dest.OrderLines, opt => opt.MapFrom(src => src.OrderLines));

		CreateMap<ProductDto, ProductResponse>();
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