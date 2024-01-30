using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;

public class GetAllGroupsQuery() : IRequest<List<GroupDto>>;