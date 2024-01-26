using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups;

public class GetAllGroupsQuery() : IRequest<List<ProductGroupDto>>;