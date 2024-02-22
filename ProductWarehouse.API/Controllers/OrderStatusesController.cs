using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Responses.Order;
using ProductWarehouse.Application.Features.Queries.OrderStatuses;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing order statuses related operations.
/// </summary>
public class OrderStatusesController : BaseController
{
	/// <summary>
	/// Get all order statuses.
	/// </summary>
	/// <returns>A list of all order statuses.</returns>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetOrderStatuses(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetAllOrderStatusesQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var orderStatuses = mapper.Map<List<OrderStatusResponse>>(result);

		return Ok(orderStatuses);
	}

	/// <summary>
	/// Get an order status by ID.
	/// </summary>
	/// <param name="request">The ID of the order status to retrieve.</param>
	/// <returns>The order status with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetOrderStatus(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator,
		CancellationToken cancellationToken)
	{
		var query = mapper.Map<GetOrderStatusQuery>(request);
		var result = await mediator.Send(query, cancellationToken);
		var orderStatus = mapper.Map<OrderStatusResponse>(result);

		return Ok(orderStatus);
	}
}