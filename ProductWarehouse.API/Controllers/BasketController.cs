using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Basket;
using ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
using ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketItem;
using ProductWarehouse.Application.Features.Queries.Basket;

namespace ProductWarehouse.API.Controllers;
public class BasketController : BaseController
{
    [HttpGet("{userId:long}")]
    public async Task<IActionResult> GetBasket(
        [FromServices] IMediator mediator,
        Guid userId)
    {
        var basket = await mediator.Send(new GetBasketQuery(userId));

        if (basket == null)
        {
            return NotFound();
        }

        return Ok(basket);
    }


    [HttpPost]
    public async Task<IActionResult> CreateBasket(
       [FromBody] CreateBasketRequest request,
       [FromServices] IMapper mapper,
       [FromServices] IMediator mediator)
    {
        if (request == null)
        {
            return BadRequest("Request body is null");
        }

        var result = mapper.Map<CreateBasketCommand>(request);
        var id = await mediator.Send(result);

        return CreatedAtAction(nameof(GetBasket), new { userId = request.UserId }, request);
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteBasket(
        [FromServices] IMediator mediator,
        [FromBody] Guid userId)
    {
        await mediator.Send(new DeleteBasketCommand(userId));

        return NoContent();
    }

    //[HttpPost]
    //public async Task<IActionResult> UdpateBasketItem([FromBody] Guid userId)
    //{
    //    return Ok();
    //}

    [HttpDelete]
    public async Task<IActionResult> DeleteBasketItem(
      [FromServices] IMediator mediator,
      [FromBody] DeleteBasketItemCommandHandler deleteBasketCommand)
    {
        await mediator.Send(deleteBasketCommand);

        return NoContent();
    }
}
