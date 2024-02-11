using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
using ProductWarehouse.API.Models.Requests.Product.Size;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;

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
        if (result == null)
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
        var command = mapper.Map<CreateProductSizeCommand>(request);
        var resultId = mediator.Send(command);

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
