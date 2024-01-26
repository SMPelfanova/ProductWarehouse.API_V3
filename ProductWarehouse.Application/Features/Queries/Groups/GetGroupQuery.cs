using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups;

public record GetGroupQuery(Guid Id) : IRequest<ProductGroupDto>;