using MediatR;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
public record GetProductSizesQuery(Guid Id) : IRequest<List<ProductSizeDto>>;