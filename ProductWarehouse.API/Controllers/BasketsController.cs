using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.API.Models.Responses.Basket;
using ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;
using ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
using ProductWarehouse.Application.Features.Queries.Basket.GetBasket;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing user baskets.
/// </summary>
public class BasketsController : BaseController
{
	/// <summary>
	/// Retrieve a user's basket by user ID.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <returns>Returns the user's basket.</returns>
	[HttpGet("{userId:guid}")]
	public async Task<IActionResult> GetBasket(
		Guid userId,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var result = await mediator.Send(new GetBasketQuery(userId));
		var basket = mapper.Map<BasketResponse>(result);

		return Ok(basket);
	}

	/// <summary>
	/// Delete a user's basket by user ID.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <returns>Returns no content.</returns>
	[HttpDelete("{userId:guid}")]
	public async Task<IActionResult> DeleteBasket(
		Guid userId,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteBasketCommand(userId));

		return NoContent();
	}

	/// <summary>
	/// Add a new basket line to the user's basket.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="addBasketLineRequest">Basket line request.</param>
	/// <returns>Returns the ID of the added basket line.</returns>
	[HttpPost("{userId:guid}")]
	public async Task<IActionResult> AddBasketLine(
		Guid userId,
		[FromBody] AddBasketLineRequest addBasketLineRequest,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<AddBasketLineCommand>(addBasketLineRequest);
		command.UserId = userId;
		var result = await mediator.Send(command);

		return Ok(result);
	}

	/// <summary>
	/// Delete a basket line from the user's basket by basket line ID.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="basketLineId">Basket line ID.</param>
	/// <returns>Returns no content.</returns>
	[HttpDelete("{userId:guid}/{basketLineId:guid}")]
	public async Task<IActionResult> DeleteBaskeLine(
		 Guid userId,
		 Guid basketLineId,
		 [FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteBasketLineCommand(userId, basketLineId));

		return NoContent();
	}

	/// <summary>
	/// Update a basket line in the user's basket.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="updatedBasketRequest">Updated basket request.</param>
	/// <returns>Returns ok.</returns>
	[HttpPut("{userId:guid}")]
	public async Task<IActionResult> UpdateBasketLine(
		Guid userId,
		[FromBody] UpdateBasketLineRequest updatedBasketRequest,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<UpdateBasketLineCommand>(updatedBasketRequest);
		command.UserId = userId;
		await mediator.Send(command);

		return Ok();
	}
}