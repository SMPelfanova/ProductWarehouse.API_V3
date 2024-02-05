using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;
public record GetProductGroupsQuery(Guid Id) : IRequest<GroupDto>;