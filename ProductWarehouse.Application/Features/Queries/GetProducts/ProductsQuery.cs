using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public record ProductsQuery(decimal? MinPrice = 0, decimal? MaxPrice = 0, string Size = "", string Highlight = "") : IRequest<ProductsFilterDto>;