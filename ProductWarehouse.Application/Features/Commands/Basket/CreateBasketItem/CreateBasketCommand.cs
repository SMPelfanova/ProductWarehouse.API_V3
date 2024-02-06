using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
public record CreateBasketCommand(BasketDto Basket) : IRequest<Guid>;