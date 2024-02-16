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
/// Controller for managing orders related operations.
/// </summary>
public class OrdersController : BaseController
{

	/// <summary>
	/// Get orders for a specific user.
	/// </summary>
	/// <param name="userId">The ID of the user whose orders are to be retrieved.</param>
	/// <returns>The orders for the specified user.</returns>
	[HttpGet("{userId:guid}")]
	public async Task<IActionResult> GetOrders(
		Guid userId,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var orders = await mediator.Send(new GetAllOrdersQuery(userId));

		//if (!orders.Any())
		//{
		//	return NotFound();
		//}
		var result = mapper.Map<List<OrderStatusResponse>>(orders);

		return Ok(result);
	}

	/// <summary>
	/// Get orders for a specific user.
	/// </summary>
	/// <param name="userId">The ID of the user whose orders are to be retrieved.</param>
	/// <returns>The orders for the specified user.</returns>
	[HttpGet("{userId:guid}/{id:guid}")]
	public async Task<IActionResult> GetOrder(
		Guid id,
		Guid userId,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var order = await mediator.Send(new GetOrderQuery(id, userId));
		var result = mapper.Map<OrderStatusResponse>(order);

		return Ok(result);
	}

	/// <summary>
	/// Create a new order.
	/// </summary>
	/// <param name="createOrderRequest">The request object containing order details.</param>
	/// <returns>The created order.</returns>
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

	/// <summary>
	/// Partially update an existing order.
	/// </summary>
	/// <param name="id">The ID of the order to update.</param>
	/// <param name="patchDocument">The JSON patch document containing updates.</param>
	/// <returns>No content if successful.</returns>
	[HttpPatch("{id:guid}")]
	public async Task<IActionResult> PartiallyUpdateOrder(
		Guid id,
		[FromBody] JsonPatchDocument<UpdateOrderRequest> patchDocument,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var command = mapper.Map<JsonPatchDocument<PartialUpdateOrderCommandRequest>>(patchDocument);
		await mediator.Send(new PartialUpdateOrderCommand() { Id = id, PatchDocument = command });

		return NoContent();
	}

	/// <summary>
	/// Delete an order by ID.
	/// </summary>
	/// <param name="id">The ID of the order to delete.</param>
	/// <returns>No content if successful.</returns>
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteOrder(
		Guid id,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteOrderCommand(id));

		return NoContent();
	}
}