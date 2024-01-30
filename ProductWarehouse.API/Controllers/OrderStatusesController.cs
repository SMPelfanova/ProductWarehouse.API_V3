using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;
using ProductWarehouse.Application.Features.Queries.Groups.GetGroup;
using ProductWarehouse.Application.Features.Queries.OrderStatuses;

namespace ProductWarehouse.API.Controllers;
public class OrderStatusesController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetOrderStatuses([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllOrderStatusesQuery());

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderStatus([FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetOrderStatusQuery(id));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

}
