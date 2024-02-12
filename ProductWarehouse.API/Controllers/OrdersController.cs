using Microsoft.AspNetCore.JsonPatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
using ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.API.Models.Requests;
using AutoMapper;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.API.Models.Requests.Order;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing orders-related operations.
/// </summary>
public class OrdersController : BaseController
{
	[HttpGet("{userId:guid}")]
	[Produces("application/json")]
	public async Task<IActionResult> GetOrders(
		Guid userId,
		[FromServices] IMediator mediator)
	{
		var orders = await mediator.Send(new GetAllOrdersQuery(userId));

		if (orders == null || !orders.Any())
		{
			return NotFound();
		}

		return Ok(orders);
	}

	[HttpGet("{userId:guid}/{id:guid}")]
	public async Task<IActionResult> GetOrder(
		Guid id,
		Guid userId,
		[FromServices] IMediator mediator)
	{
		var order = await mediator.Send(new GetOrderQuery(id, userId));

		if (order == null)
		{
			return NotFound();
		}

		return Ok(order);
	}

	[HttpPost]
	public async Task<IActionResult> CreateOrder(
	[FromBody] CreateOrderRequest createOrderRequest,
	[FromServices] IMapper mapper,
	[FromServices] IMediator mediator)
	{
		if (createOrderRequest == null)
		{
			return BadRequest("Request body is null");
		}

		var command = mapper.Map<CreateOrderCommand>(createOrderRequest);

		var orderId = await mediator.Send(command);

		return CreatedAtAction(nameof(GetOrder), new { id = orderId }, createOrderRequest);
	}

	[HttpPatch("{id:guid}")]
	public async Task<IActionResult> PartiallyUpdateOrder(
		Guid id,
		[FromBody] JsonPatchDocument<UpdateOrderRequest> patchDocument,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var command = mapper.Map<JsonPatchDocument<PartialUpdateOrderRequest>>(patchDocument);
		await mediator.Send(new PartialUpdateOrderCommand() { Id = id, PatchDocument = command });

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteOrder(
		Guid id,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteOrderCommand(id));

		return NoContent();
	}
}
