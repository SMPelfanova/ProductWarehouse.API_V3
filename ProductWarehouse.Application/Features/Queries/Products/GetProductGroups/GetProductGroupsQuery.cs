using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;
public record GetProductSizesQuery(Guid Id) : IRequest<GroupDto>;