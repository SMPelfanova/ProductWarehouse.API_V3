using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

namespace ProductWarehouse.API.Controllers;

[Route("api/products")]
public class ProductGroupsController : BaseController
{

    [HttpGet("{id:guid}/groups")]
    public async Task<IActionResult> GetProductGroups([FromServices] IMediator mediator, Guid productId)
    {
        var result = await mediator.Send(new GetProductGroupsQuery(productId));
        if (result == null)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPost("{id:guid}/groups")]
    public async Task<IActionResult> CreateProductGroup(
        [FromServices] IMediator mediator,
        Guid productId,
        [FromBody] CreateProductGroupCommand createProductGroupCommand)
    {
        var resultId = mediator.Send(createProductGroupCommand);

        return Ok(resultId);
    }

    [HttpDelete("{productId:guid}/groups/{groupId:guid}")]
    public async Task<IActionResult> DeleteProductGroup([FromServices] IMediator mediator, Guid productId, Guid groupId)
    {
        await mediator.Send(new DeleteProductGroupCommand(productId, groupId));

        return NoContent();
    }
}
