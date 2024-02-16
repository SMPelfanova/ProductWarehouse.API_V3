using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
using ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing brands related operations.
/// </summary>
public class BrandsController : BaseController
{
	/// <summary>
	/// Get all brands.
	/// </summary>
	/// <returns>A list of all brands.</returns>
	[HttpGet]
	public async Task<IActionResult> GetBrands([FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetAllBrandsQuery());

		return Ok(result);
	}

	/// <summary>
	/// Get a brand by ID.
	/// </summary>
	/// <param name="id">The ID of the brand to retrieve.</param>
	/// <returns>The brand with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetBrand(Guid id, [FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetBrandQuery(id));

		return Ok(result);
	}
}