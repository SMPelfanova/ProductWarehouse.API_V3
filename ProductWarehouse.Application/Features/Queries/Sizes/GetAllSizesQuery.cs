using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public class GetAllSizesQuery() : IRequest<List<SizeDto>>;