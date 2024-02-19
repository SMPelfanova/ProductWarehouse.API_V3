using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;
using ProductWarehouse.Application.Features.Queries.Groups.GetGroup;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing groups related operations.
/// </summary>
public class GroupsController : BaseController
{
	/// <summary>
	/// Get all groups.
	/// </summary>
	/// <returns>A list of all groups.</returns>
	[HttpGet]
	public async Task<IActionResult> GetGroups(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetAllGroupsQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Get a group by ID.
	/// </summary>
	/// <param name="request">The ID of the group to retrieve.</param>
	/// <returns>The group with the specified ID.</returns>[HttpGet("{id:guid}")]
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetGroup(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetGroupQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}
}