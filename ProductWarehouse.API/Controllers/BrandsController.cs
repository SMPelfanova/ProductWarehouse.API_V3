using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Responses.Brands;
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
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetBrands(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetAllBrandsQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var brands = mapper.Map<List<BrandResponse>>(result);

		return Ok(brands);
	}

	/// <summary>
	/// Get a brand by ID.
	/// </summary>
	/// <param name="request">The ID of the brand to retrieve.</param>
	/// <returns>The brand with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetBrand(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetBrandQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var brand = mapper.Map<BrandResponse>(result);

		return Ok(brand);
	}
}