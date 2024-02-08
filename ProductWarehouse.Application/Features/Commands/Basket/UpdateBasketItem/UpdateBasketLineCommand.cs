using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketItem;
public record UpdateBasketLineCommand(Guid UserId, BasketLineDto BasketLine) : IRequest;