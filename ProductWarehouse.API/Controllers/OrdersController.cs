using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Base;
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
	/// <param name="request">The ID of the user whose orders are to be retrieved.</param>
	/// <returns>The orders for the specified user.</returns>
	[HttpGet("{userId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetOrders(
		[FromRoute] BaseRequestUserId request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var query = mapper.Map<GetAllOrdersQuery>(request);
		var orders = await mediator.Send(query);
		var result = mapper.Map<List<OrderResponse>>(orders);

		return Ok(result);
	}

	/// <summary>
	/// Get orders for a specific user.
	/// </summary>
	/// <param name="request">The ID of the user whose orders are to be retrieved.</param>
	/// <returns>The orders for the specified user.</returns>
	[HttpGet("{userId:guid}/{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetOrder(
		[FromRoute] GetOrderRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var query = mapper.Map<GetOrderQuery>(request);
		var order = await mediator.Send(query);
		var result = mapper.Map<OrderResponse>(order);

		return Ok(result);
	}

	/// <summary>
	/// Create a new order.
	/// </summary>
	/// <param name="createOrderRequest">The request object containing order details.</param>
	/// <returns>The created order.</returns>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public async Task<IActionResult> CreateOrder(
	[FromBody] CreateOrderRequest createOrderRequest,
	[FromServices] IMapper mapper,
	[FromServices] IMediator mediator)
	{
		var command = mapper.Map<CreateOrderCommand>(createOrderRequest);

		var order = await mediator.Send(command);

		var orderResponse = mapper.Map<OrderResponse>(order);

		return CreatedAtAction(nameof(GetOrder), new { id = orderResponse.Id, userId = orderResponse.UserId }, orderResponse);
	}

	/// <summary>
	/// Partially update an existing order.
	/// </summary>
	/// <param name="id">The ID of the order to update.</param>
	/// <param name="patchDocument">The JSON patch document containing updates.</param>
	/// <returns>No content if successful.</returns>
	[HttpPatch("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
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
	/// <param name="request">The ID of the order to delete.</param>
	/// <returns>No content if successful.</returns>
	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> DeleteOrder(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<DeleteOrderCommand>(request);
		await mediator.Send(command);

		return NoContent();
	}
}