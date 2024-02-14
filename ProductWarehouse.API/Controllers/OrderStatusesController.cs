using MediatR;
using Microsoft.AspNetCore.Mvc;
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
	public async Task<IActionResult> GetOrderStatuses([FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetAllOrderStatusesQuery());
		if (result == null || !result.Any())
		{
			return NotFound();
		}

		return Ok(result);
	}

	/// <summary>
	/// Get an order status by ID.
	/// </summary>
	/// <param name="id">The ID of the order status to retrieve.</param>
	/// <returns>The order status with the specified ID.</returns>
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> GetOrderStatus(Guid id, [FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetOrderStatusQuery(id));

		if (result == null)
		{
			return NotFound();
		}

		return Ok(result);
	}
}