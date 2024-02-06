using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketItem;
public record DeleteBasketItemCommand(Guid userId, Guid basketId) : IRequest;