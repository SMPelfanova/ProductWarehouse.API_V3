using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
{
    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
    }
}
