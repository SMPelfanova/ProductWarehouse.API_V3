using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.Application.Features.Queries.Sizes;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing size related operations.
/// </summary>
public class SizesController : BaseController
{
	/// <summary>
	/// Retrieves all sizes.
	/// </summary>
	/// <returns>A list of sizes.</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetSizes(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetAllSizesQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Retrieves a size by its ID.
	/// </summary>
	/// <param name="request">The ID of the size.</param>
	/// <returns>The size with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetSize(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetSizeQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}
}