using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;
public record DeleteBasketLineCommand(Guid userId, Guid basketLineId) : IRequest;