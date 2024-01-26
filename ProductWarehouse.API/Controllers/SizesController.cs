using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Queries.GetProduct;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Features.Queries.Sizes;

namespace ProductWarehouse.API.Controllers;
public class SizesController : BaseController
{
    public SizesController(ILogger<OrdersController> logger, IMediator mediator, IMapper mapper)
    : base(logger, mediator, mapper)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get()
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
