using AutoMapper;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Mapping;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		FromEntityToDto();

		MapFromDtoToEntity();

		MapFromCommandToEntity();

		MapProductFilter();
	}

	private void FromEntityToDto()
	{
		CreateMap<Brand, BrandDto>().ReverseMap();
		CreateMap<Group, GroupDto>().ReverseMap();
		CreateMap<BasketLine, BasketLineDto>().ReverseMap();

		CreateMap<Baskets, BasketDto>()
		   .ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<Order, OrderDto>().ReverseMap();
		CreateMap<OrderLine, OrderLineDto>().ReverseMap();
		CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
		CreateMap<ProductSize, ProductSizeDto>().ReverseMap();

		CreateMap<ProductSize, SizeDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Size.Id))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Size.Name))
			.ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));

		CreateMap<ProductGroups, GroupDto>()
		   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Group.Id))
		   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Group.Name));

	}

	private void MapFromDtoToEntity()
	{
		CreateMap<BasketDto, Baskets>()
			.ForMember(dest => dest.BasketLines, opt => opt.MapFrom(src => src.BasketLines));

		CreateMap<Size, SizeDto>().ReverseMap();
		CreateMap<GroupDto, ProductGroups>()
			.ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Id));

		CreateMap<SizeDto, ProductSize>()
			.ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.Id))
			.ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));

	}

	private void MapFromCommandToEntity()
	{
		CreateMap<CreateProductGroupCommand, ProductGroups>();
		CreateMap<CreateProductSizeCommand, ProductSize>();
		CreateMap<UpdateProductCommand, Product>();
		CreateMap<AddBasketLineCommand, BasketLine>();
		
		CreateMap<UpdateProductSizeCommand, ProductSize>()
			.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

		CreateMap<CreateProductCommand, Product>()
			.ForMember(dest => dest.ProductGroups, opt => opt.MapFrom(src => src.Groups))
			.ForMember(dest => dest.ProductSizes, opt => opt.MapFrom(src => src.Sizes));
	}

	private void MapProductFilter()
	{
		CreateMap<Product, ProductDto>()
	   .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
	   .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.ProductSizes
		   .Select(ps => new SizeDto
		   {
			   Id = ps.Size.Id,
			   Name = ps.Size.Name,
			   QuantityInStock = ps.QuantityInStock
		   }).ToList()))
	   .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src
	   .ProductGroups.Select(pg => pg.Group))).ReverseMap();

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