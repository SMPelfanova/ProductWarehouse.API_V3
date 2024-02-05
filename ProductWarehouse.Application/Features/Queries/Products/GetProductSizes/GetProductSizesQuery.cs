using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
public record GetProductSizesQuery(Guid Id) : IRequest<SizeDto>;