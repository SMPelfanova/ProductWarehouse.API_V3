using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.API.Models.Responses.Basket;
using ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketItem;
using ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketItem;
using ProductWarehouse.Application.Features.Queries.Basket;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Controllers;
public class BasketController : BaseController
{
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetBasket(
        Guid userId,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetBasketQuery(userId));
        var basket = mapper.Map<BasketResponse>(result);
        if (basket == null)
        {
            return NotFound();
        }

        return Ok(basket);
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteBasket(
        Guid userId,
        [FromServices] IMediator mediator)
    {
        await mediator.Send(new DeleteBasketCommand(userId));

        return NoContent();
    }

    [HttpPost("{userId:guid}")]
    public async Task<IActionResult> AddBasketLine(
        Guid userId,
        [FromBody] BasketLineRequest basketLineRequest,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator)
    {
        var mappedLine = mapper.Map<BasketLineDto>(basketLineRequest);
        var result = await mediator.Send(new AddBasketLineCommand(userId, mappedLine));

        return Ok(result);
    }

    [HttpDelete("{userId:guid}/{productId:guid}")]
    public async Task<IActionResult> DeleteBaskeLine(
         Guid userId,
         Guid productId,
         [FromServices] IMediator mediator)
    {
        await mediator.Send(new DeleteBasketItemCommand(userId, productId));

        return NoContent();
    }

    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateBasketLine(
        Guid userId,
        [FromBody] UpdateBasketRequest updatedBasketRequest,
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator)
    {
        var mappedLine = mapper.Map<BasketLineDto>(updatedBasketRequest.BasketLine);
        await mediator.Send(new UpdateBasketLineCommand(userId, mappedLine));

        return Ok();
    }

}
