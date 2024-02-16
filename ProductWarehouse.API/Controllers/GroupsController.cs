using MediatR;
using Microsoft.AspNetCore.Mvc;
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
	public async Task<IActionResult> GetGroups([FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetAllGroupsQuery());

		return Ok(result);
	}

	/// <summary>
	/// Get a group by ID.
	/// </summary>
	/// <param name="id">The ID of the group to retrieve.</param>
	/// <returns>The group with the specified ID.</returns>[HttpGet("{id:guid}")]
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetGroup(Guid id, [FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetGroupQuery(id));

		return Ok(result);
	}
}