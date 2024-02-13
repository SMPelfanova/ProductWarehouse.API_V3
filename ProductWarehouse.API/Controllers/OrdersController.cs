using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Order;
using ProductWarehouse.API.Models.Responses.Order;
using ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
using ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
using ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
using ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

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
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var orders = await mediator.Send(new GetAllOrdersQuery(userId));

		if (!orders.Any())
		{
			return NotFound();
		}
		var result = mapper.Map<List<OrderResponse>>(orders);

		return Ok(result);
	}

	[HttpGet("{userId:guid}/{id:guid}")]
	public async Task<IActionResult> GetOrder(
		Guid id,
		Guid userId,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var order = await mediator.Send(new GetOrderQuery(id, userId));
		if (order == null)
		{
			return NotFound();
		}

		var result = mapper.Map<OrderResponse>(order);

		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> CreateOrder(
	[FromBody] CreateOrderRequest createOrderRequest,
	[FromServices] IMapper mapper,
	[FromServices] IMediator mediator)
	{
		var command = mapper.Map<CreateOrderCommand>(createOrderRequest);

		var orderId = await mediator.Send(command);

		return CreatedAtAction(nameof(GetOrder), new { id = orderId, userId = createOrderRequest.UserId }, createOrderRequest);
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