using Microsoft.AspNetCore.JsonPatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
using ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing orders-related operations.
/// </summary>
public class OrdersController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetOrders(
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllOrdersQuery());

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder(
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

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromServices] IMediator mediator,
        Guid id,
        CreateOrderCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateOrder(
        [FromServices] IMediator mediator,
        Guid id,
        [FromBody] UpdateOrderCommand updateOrderCommand)
    {
        await mediator.Send(new UpdateOrderCommand(id, updateOrderCommand.order));
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateOrder(
        [FromServices] IMediator mediator,
        Guid id,
        [FromBody] JsonPatchDocument<OrderDto> patchDocument)
    {
        await mediator.Send(new PartialUpdateOrderCommand() {Id = id, PatchDocument = patchDocument });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(
        [FromServices] IMediator mediator,
        Guid id)
    {
        await mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}
