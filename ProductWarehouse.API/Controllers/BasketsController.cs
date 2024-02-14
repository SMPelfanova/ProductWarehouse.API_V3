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
using ProductWarehouse.Application.Models;

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
		//todo: check when validation failes and userId not found
		if (result == null)
		{
			return NotFound();
		}
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
	/// <param name="basketLineRequest">Basket line request.</param>
	/// <returns>Returns the ID of the added basket line.</returns>
	[HttpPost("{userId:guid}")]
	public async Task<IActionResult> AddBasketLine(
		Guid userId,
		[FromBody] BasketLineRequest basketLineRequest,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var mappedLine = mapper.Map<BasketLineDto>(basketLineRequest);
		var result = await mediator.Send(new AddBasketLineCommand(userId, mappedLine));
		if (result == Guid.Empty)
		{
			return NotFound("No products found with requested size.");
		}

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
		[FromBody] UpdateBasketRequest updatedBasketRequest,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		//var mappedLine = mapper.Map<BasketLineDto>(updatedBasketRequest.BasketLine);
		var command = mapper.Map<UpdateBasketLineCommand>(updatedBasketRequest);
		await mediator.Send(command);

		return Ok();
	}
}