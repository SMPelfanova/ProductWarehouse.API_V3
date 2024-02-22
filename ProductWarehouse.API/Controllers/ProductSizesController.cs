using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.API.Models.Responses.Product;
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
	/// <param name="request">The ID of the product.</param>
	/// <returns>The product sizes.</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetProductSizes(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetProductSizesQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var productSizesResonse = mapper.Map<List<ProductSizeResponse>>(result);

		return Ok(productSizesResonse);
	}

	/// <summary>
	/// Creates a new product size.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <param name="request">The request containing the product size details.</param>
	/// <returns>The newly created product size.</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<IActionResult> CreateProductSize(
		Guid id,
		[FromBody] CreateProductSizeRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper,
		CancellationToken cancellationToken)
	{
		var command = mapper.Map<CreateProductSizeCommand>(request);
		var result = await mediator.Send(command, cancellationToken);
		var productSizeResonse = mapper.Map<ProductSizeResponse>(result);

		return CreatedAtAction(nameof(GetProductSizes), new { id = id }, productSizeResonse);
	}

	/// <summary>
	/// Deletes a product size by product and size IDs.
	/// </summary>
	/// <param name="request.id">The ID of the product.</param>
	/// <param name="request.sizeId">The ID of the size.</param>
	/// <returns>No content if the deletion is successful.</returns>
	[HttpDelete("{sizeId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> DeleteProductSize(
		[FromRoute] DeleteProductSizeRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var command = mapper.Map<DeleteProductSizeCommand>(request);
		await mediator.Send(command, cancellationToken);

		return NoContent();
	}

	/// <summary>
	/// Updates the quantity in stock of a product size.
	/// </summary>
	/// <param name="request.id">The ID of the product.</param>
	/// <param name="request.sizeId">The ID of the size.</param>
	/// <param name="QuantityInStock">The updated quantity in stock.</param>
	/// <returns>No content if the update is successful.</returns>
	[HttpPut("{sizeId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> UpdateProductSize(
		[FromRoute] UpdateProductSizeRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<UpdateProductSizeCommand>(request);
		await mediator.Send(command);

		return NoContent();
	}
}