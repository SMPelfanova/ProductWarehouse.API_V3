using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Requests.Product.Group;
using ProductWarehouse.API.Models.Responses.Group;
using ProductWarehouse.API.Models.Responses.Product;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product groups related operations.
/// </summary>
[Route("api/products/{id:guid}/groups")]
public class ProductGroupsController : BaseController
{
	/// <summary>
	/// Retrieves all product groups for a specified product.
	/// </summary>
	/// <param name="request">The ID of the product.</param>
	/// <returns>A list of product groups associated with the specified product.</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetProductGroups(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetProductGroupsQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var productGroupsResonse = mapper.Map<List<GroupResponse>>(result);

		return Ok(productGroupsResonse);
	}

	/// <summary>
	/// Creates a new product group for a specified product.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="request">The request containing the group ID.</param>
	/// <returns>The newly created product group.</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<IActionResult> CreateProductGroup(
		Guid id,
		[FromBody] CreateProductGroupRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper,
		CancellationToken cancellationToken)
	{
		var command = mapper.Map<CreateProductGroupCommand>(request);
		var result = await mediator.Send(command, cancellationToken);
		var productGroupsResonse = mapper.Map<ProductGroupResponse>(result);

		return CreatedAtAction(nameof(GetProductGroups), new { id = request.Id }, productGroupsResonse);
	}

	/// <summary>
	/// Deletes a product group for a specified product.
	/// </summary>
	/// <param name="request.id">The ID of the product.</param>
	/// <param name="request.groupId">The ID of the group to be deleted.</param>
	/// <returns>No content if the deletion is successful.</returns>
	[HttpDelete("{groupId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> DeleteProductGroup(
		[FromRoute] DeleteProductGroupRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var command = mapper.Map<DeleteProductGroupCommand>(request);
		await mediator.Send(command, cancellationToken);

		return NoContent();
	}
}