using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
public record CreateBasketCommand() : IRequest<Guid>
{
    public Guid UserId { get; set; }

    public List<BasketLineDto> Items { get; set; }
}