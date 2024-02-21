using MediatR;
using ProductWarehouse.Application.Models.Group;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;
public record GetProductGroupsQuery(Guid Id) : IRequest<List<GroupDto>>;