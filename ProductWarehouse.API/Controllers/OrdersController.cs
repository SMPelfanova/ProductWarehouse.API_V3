using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Orders.AddOrder;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

namespace ProductWarehouse.API.Controllers;
public class OrdersController : BaseController
{
    public OrdersController(ILogger<OrdersController> logger, IMediator mediator, IMapper mapper)
     : base(logger, mediator, mapper)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetOrders()
    {
        var result = await _mediator.Send(new GetAllOrdersQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetOrder(Guid id)
    {
        var product = await _mediator.Send(new GetOrderQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
