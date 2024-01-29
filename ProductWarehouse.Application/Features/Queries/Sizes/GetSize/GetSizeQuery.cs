using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public record GetSizeQuery(Guid Id) : IRequest<SizeDto>;