using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetGroup;

public record GetGroupQuery(Guid Id) : IRequest<ProductGroupDto>;