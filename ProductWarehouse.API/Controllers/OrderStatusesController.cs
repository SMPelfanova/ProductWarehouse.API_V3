using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.OrderStatuses;

namespace ProductWarehouse.API.Controllers;

public class OrderStatusesController : BaseController
{
	[HttpGet]
	[Produces("application/json")]
	public async Task<IActionResult> GetOrderStatuses([FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetAllOrderStatusesQuery());
		if (result == null || !result.Any())
		{
			return NotFound();
		}

		return Ok(result);
	}

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