using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Basket;

namespace ProductWarehouse.API.Controllers;
public class BasketController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBasket(
        [FromServices] IMediator mediator,
        [FromBody] Guid userId)
    {
        var basket = mediator.Send(new GetBasketQuery(userId));

        if (basket == null)
        {
            return NotFound();
        }

        return Ok(basket);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket([FromBody] Guid userId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBasketItem([FromBody] Guid userId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UdpateBasketItem([FromBody] Guid userId)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasketItem([FromBody] Guid userId)
    {
        return Ok();
    }
}
