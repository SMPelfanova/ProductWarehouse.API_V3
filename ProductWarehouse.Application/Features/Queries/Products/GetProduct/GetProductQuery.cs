using MediatR;
using ProductWarehouse.Application.Models.Product;

namespace ProductWarehouse.Application.Features.Queries.GetProduct;

public record GetProductQuery(Guid Id) : IRequest<ProductDto>;