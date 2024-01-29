using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing orders-related operations.
/// </summary>
public class OrdersController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetOrders(
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllOrdersQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetOrders(
        [FromServices] IMediator mediator,
        Guid id)
    {
        var product = await mediator.Send(new GetOrderQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    //{
    //   // var orderId = await _mediator.Send(command);
    //    return CreatedAtAction(nameof(Application.Features.Queries.Orders.GetOrder), new { orderId });
    //}

    //[HttpPut("{orderId}")]
    //public async Task<IActionResult> UpdateOrder(Guid orderId, [FromBody] UpdateOrderCommand command)
    //{
    //    command.OrderId = orderId;
    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
       // await _mediator.Send(new DeleteOrderCommand { OrderId = orderId });
        return NoContent();
    }
}
