using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;
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
	public async Task<IActionResult> GetOrderStatuses(
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetAllOrderStatusesQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}

	/// <summary>
	/// Get an order status by ID.
	/// </summary>
	/// <param name="request">The ID of the order status to retrieve.</param>
	/// <returns>The order status with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetOrderStatus(
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper, 
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetOrderStatusQuery>(request);
		var result = await mediator.Send(query);

		return Ok(result);
	}
}