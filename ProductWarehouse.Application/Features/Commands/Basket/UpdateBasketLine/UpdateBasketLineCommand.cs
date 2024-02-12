using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
public record UpdateBasketLineCommand(Guid UserId, BasketLineDto BasketLine) : IRequest<Guid>;