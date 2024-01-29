using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Sizes;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-sizes-related operations.
/// </summary>
public class SizesController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetSizes([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllSizesQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetSize([FromServices] IMediator mediator, Guid id)
    {
        var product = await mediator.Send(new GetSizeQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

}
