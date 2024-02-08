
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
        var basketToDelete = _unitOfWork.Basket.GetBasketByUserId(request.userId);
        if (basketToDelete != null)
        {
            _unitOfWork.Basket.DeleteBasketLine(request.userId, request.basketId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
