using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketItem;
public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBasketItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Basket.DeleteBasketLine(request.userId, request.productId);

        await _unitOfWork.SaveChangesAsync();
    }
}
