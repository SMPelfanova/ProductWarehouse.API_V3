using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
public record AddBasketLineCommand(Guid UserId, BasketLineDto BasketLine) : IRequest<Guid>;