using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product sizes related operations.
/// </summary>
[Route("api/products/{id:guid}/sizes")]
public class ProductSizesController : BaseController
{
	/// <summary>
	/// Retrieves product sizes by product ID.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <returns>The product sizes.</returns>
	[HttpGet]
	public async Task<IActionResult> GetProductSizes(
		Guid id,
		[FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetProductSizesQuery(id));
		if (!result.Any())
		{
			return NotFound();
		}

		return Ok(result);
	}

	/// <summary>
	/// Creates a new product size.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="request">The request containing the product size details.</param>
	/// <returns>The newly created product size.</returns>
	[HttpPost]
	public async Task<IActionResult> CreateProductSize(
		Guid id,
		[FromBody] CreateProductSizeRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var command = mapper.Map<CreateProductSizeCommand>(request);
		var resultId = await mediator.Send(command);

		return CreatedAtAction(nameof(GetProductSizes), new { id = id }, request);
	}

	/// <summary>
	/// Deletes a product size by product and size IDs.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="sizeId">The ID of the size.</param>
	/// <returns>No content if the deletion is successful.</returns>
	[HttpDelete("{sizeId:guid}")]
	public async Task<IActionResult> DeleteProductSize(
		Guid id,
		Guid sizeId,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteProductSizeCommand(id, sizeId));

		return NoContent();
	}

	/// <summary>
	/// Updates the quantity in stock of a product size.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="sizeId">The ID of the size.</param>
	/// <param name="QuantityInStock">The updated quantity in stock.</param>
	/// <returns>No content if the update is successful.</returns>
	[HttpPut("{sizeId:guid}")]
	public async Task<IActionResult> UpdateProductSize(
		Guid id,
		Guid sizeId,
		int QuantityInStock,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new UpdateProductSizeCommand(id, sizeId, QuantityInStock));

		return NoContent();
	}
}