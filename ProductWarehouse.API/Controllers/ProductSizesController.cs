using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

namespace ProductWarehouse.API.Controllers;

[Route("api/products/{id:guid}/sizes")]
public class ProductSizesController : BaseController
{
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

	[HttpPost]
	public async Task<IActionResult> CreateProductSize(
		Guid id,
		[FromBody] CreateProductSizeRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var resultId = await mediator.Send(new CreateProductSizeCommand(request.Id, request.SizeId, request.QuantityInStock));

		return CreatedAtAction(nameof(GetProductSizes), new { id = id }, request);
	}

	[HttpDelete("{sizeId:guid}")]
	public async Task<IActionResult> DeleteProductSize(
		Guid id,
		Guid sizeId,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteProductSizeCommand(id, sizeId));

		return NoContent();
	}

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