using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
public record DeleteBasketCommand(Guid UserId) : IRequest;