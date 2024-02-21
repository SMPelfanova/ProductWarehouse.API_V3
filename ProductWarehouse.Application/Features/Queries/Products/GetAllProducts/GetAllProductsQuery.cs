using MediatR;
using ProductWarehouse.Application.Models.Product;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public record GetAllProductsQuery(decimal? MinPrice = 0, decimal? MaxPrice = 0, string Size = "", string Highlight = "") : IRequest<ProductsFilterDto>;