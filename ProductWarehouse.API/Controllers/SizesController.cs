using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Sizes;

namespace ProductWarehouse.API.Controllers;
public class SizesController : BaseController
{
    public SizesController(ILogger<SizesController> logger, IMediator mediator, IMapper mapper)
    : base(logger, mediator, mapper)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetSizes()
    {
        var result = await _mediator.Send(new GetAllSizesQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetSize(Guid id)
    {
        var product = await _mediator.Send(new GetSizeQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

}
