using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Base;
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
	/// <param name="request">User ID.</param>
	/// <returns>Returns the user's basket.</returns>
	[HttpGet("{userId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetBasket(
		[FromRoute] BaseRequestUserId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var comamnd = mapper.Map<GetBasketQuery>(request);
		var result = await mediator.Send(comamnd);
		var basket = mapper.Map<BasketResponse>(result);

		return Ok(basket);
	}

	/// <summary>
	/// Delete a user's basket by user ID.
	/// </summary>
	/// <param name="request">User ID.</param>
	/// <returns>Returns no content.</returns>
	[HttpDelete("{userId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> DeleteBasket(
		[FromRoute] BaseRequestUserId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var comamnd = mapper.Map<DeleteBasketCommand>(request);

		await mediator.Send(comamnd);

		return NoContent();
	}

	/// <summary>
	/// Add a new basket line to the user's basket.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="addBasketLineRequest">Basket line request.</param>
	/// <returns>Returns the ID of the added basket line.</returns>
	[HttpPost("{userId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> AddBasketLine(
		Guid userId,
		[FromBody] AddBasketLineRequest addBasketLineRequest,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<AddBasketLineCommand>(addBasketLineRequest);
		command.UserId = userId;
		var result = await mediator.Send(command);

		var basketLineRespose = mapper.Map<BasketLineResponse>(result);

		return Ok(basketLineRespose);
	}

	/// <summary>
	/// Delete a basket line from the user's basket by basket line ID.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="basketLineId">Basket line ID.</param>
	/// <returns>Returns no content.</returns>
	[HttpDelete("{userId:guid}/{basketLineId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	public async Task<IActionResult> DeleteBaskeLine(
		 [FromRoute] DeleteBasketLineRequest request,
		 [FromServices] IMapper mapper,
		 [FromServices] IMediator mediator)
	{
		var comand = mapper.Map<DeleteBasketLineCommand>(request);
		await mediator.Send(comand);

		return NoContent();
	}

	/// <summary>
	/// Update a basket line in the user's basket.
	/// </summary>
	/// <param name="userId">User ID.</param>
	/// <param name="updatedBasketRequest">Updated basket request.</param>
	/// <returns>Returns ok.</returns>
	[HttpPut("{userId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
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