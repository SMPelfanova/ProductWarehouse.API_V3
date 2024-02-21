using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.API.Models.Requests.Order;
using ProductWarehouse.API.Models.Requests.Product.Group;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.API.Models.Responses.Basket;
using ProductWarehouse.API.Models.Responses.Brands;
using ProductWarehouse.API.Models.Responses.Group;
using ProductWarehouse.API.Models.Responses.Order;
using ProductWarehouse.API.Models.Responses.Size;
using ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Features.Queries.Basket.GetBasket;
using ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
using ProductWarehouse.Application.Features.Queries.Brands.GetBrand;
using ProductWarehouse.Application.Features.Queries.GetProduct;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;
using ProductWarehouse.Application.Features.Queries.Groups.GetGroup;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;
using ProductWarehouse.Application.Features.Queries.OrderStatuses;
using ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;
using ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
using ProductWarehouse.Application.Features.Queries.Sizes;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Application.Models.Basket;
using ProductWarehouse.Application.Models.Brand;
using ProductWarehouse.Application.Models.Group;
using ProductWarehouse.Application.Models.Order;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.API.Mapping;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		MapFromRequestToQueries();
		MapFromRequestToCommands();
		MapFromDtoToResponse();
	}

	private void MapFromRequestToCommands()
	{
		CreateMap<AddBasketLineRequest, AddBasketLineCommand>();
		CreateMap<UpdateBasketLineRequest, UpdateBasketLineCommand>();

		CreateMap<SizeRequest, SizeDto>()
			.ForMember(x => x.Name, opt => opt.Ignore());
		CreateMap<ProductGroupRequest, GroupDto>()
			.ForMember(x=>x.Name, opt=>opt.Ignore());

		CreateMap<CreateProductRequest, CreateProductCommand>()
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
		CreateMap<BaseRequestUserId, DeleteBasketCommand>();
		CreateMap<BaseRequestId, DeleteOrderCommand>();
		CreateMap<DeleteBasketLineRequest, DeleteBasketLineCommand>();
		CreateMap<DeleteProductGroupRequest, DeleteProductGroupCommand>();
		CreateMap<DeleteProductSizeRequest, DeleteProductSizeCommand>();
		CreateMap<UpdateProductSizeRequest, UpdateProductSizeCommand>();
	}

	private void MapFromRequestToQueries()
	{
		CreateMap<FilterProductsRequest, GetAllProductsQuery>();

		CreateMap<BaseRequestUserId, GetBasketQuery>();
		CreateMap<BaseRequestUserId, GetAllOrdersQuery>();
		CreateMap<GetOrderRequest, GetOrderQuery>();
		
		CreateMap<BaseRequestId, GetSizeQuery>();
		CreateMap<BaseRequestId, GetOrderStatusQuery>();
		CreateMap<BaseRequestId, GetGroupQuery>();
		CreateMap<BaseRequestId, GetBrandQuery>();
		CreateMap<BaseRequestId, GetProductGroupsQuery>();
		CreateMap<BaseRequestId, GetProductSizesQuery>();
		CreateMap<BaseRequestId, GetProductQuery>();
		
		CreateMap<BaseEmptyRequest, GetAllSizesQuery>();
		CreateMap<BaseEmptyRequest, GetAllBrandsQuery>();
		CreateMap<BaseEmptyRequest, GetAllOrderStatusesQuery>();
		CreateMap<BaseEmptyRequest, GetAllGroupsQuery>();
		CreateMap<BaseEmptyRequest, GetAllProductsQuery>();
		
	}

	private void MapFromDtoToResponse()
	{
		CreateMap<BrandDto, BrandResponse>();
		CreateMap<SizeDto, SizeResponse>();
		CreateMap<GroupDto, GroupResponse>();
		CreateMap<OrderStatusDto, OrderStatusResponse>();
		
		CreateMap<BasketDto, BasketResponse>()
			.ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<BasketLineDto, BasketLineResponse>();
		CreateMap<BasketDto, BasketResponse>()
			.ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<OrderLineDto, OrderLineResponse>();

		CreateMap<OrderDto, OrderResponse>()
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