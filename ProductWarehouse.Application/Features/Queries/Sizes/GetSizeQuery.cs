using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public class GetSizeQuery(Guid Id) : IRequest<SizeDto>;