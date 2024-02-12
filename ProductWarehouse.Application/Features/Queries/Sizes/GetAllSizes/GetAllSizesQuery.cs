using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public record GetAllSizesQuery() : IRequest<List<SizeDto>>;