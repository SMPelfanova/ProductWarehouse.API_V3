using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Product.Group;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
using ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

namespace ProductWarehouse.API.Controllers;

[Route("api/products/{id:guid}/groups")]
public class ProductGroupsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetProductGroups(
        Guid id,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetProductGroupsQuery(id));
        if (!result.Any())
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductGroup(
        Guid id,
        [FromBody] CreateProductGroupRequest request,
        [FromServices] IMediator mediator)
    {
        var resultId = await mediator.Send(new CreateProductGroupCommand(id, request.GroupId));

        return CreatedAtAction(nameof(GetProductGroups), new { id = id }, request);
    }

    [HttpDelete("{groupId:guid}")]
    public async Task<IActionResult> DeleteProductGroup(
        Guid id,
        Guid groupId,
        [FromServices] IMediator mediator)
    {
        await mediator.Send(new DeleteProductGroupCommand(id, groupId));

        return NoContent();
    }
}
