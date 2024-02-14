using MediatR;
using Microsoft.AspNetCore.Mvc;
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
	public async Task<IActionResult> GetSizes([FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetAllSizesQuery());
		if (result == null || !result.Any())
		{
			return NotFound();
		}

		return Ok(result);
	}

	/// <summary>
	/// Retrieves a size by its ID.
	/// </summary>
	/// <param name="id">The ID of the size.</param>
	/// <returns>The size with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetSize([FromServices] IMediator mediator, Guid id)
	{
		var size = await mediator.Send(new GetSizeQuery(id));

		if (size == null)
		{
			return NotFound();
		}

		return Ok(size);
	}
}