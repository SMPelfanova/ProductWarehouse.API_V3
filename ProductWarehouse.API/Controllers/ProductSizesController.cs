using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

namespace ProductWarehouse.API.Controllers;

[Route("api/products")]
public class ProductSizesController : BaseController
{
    [HttpGet("{id:guid}/sizes")]
    public async Task<IActionResult> GetProductSizes([FromServices] IMediator mediator, Guid productId)
    {
        var result = await mediator.Send(new GetProductSizesQuery(productId));
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("{id:guid}/sizes")]
    public async Task<IActionResult> CreateProductSize(
        [FromServices] IMediator mediator,
        Guid productId,
        [FromBody] CreateProductSizeCommand createProductSizeCommand)
    {
        var resultId = mediator.Send(createProductSizeCommand);

        return Ok(resultId);
    }

    [HttpDelete("{productId:guid}/sizes/{sizeId:guid}")]
    public async Task<IActionResult> DeleteProductSize([FromServices] IMediator mediator, Guid productId, Guid sizeId)
    {
        await mediator.Send(new DeleteProductGroupCommand(productId, sizeId));

        return NoContent();
    }


}
