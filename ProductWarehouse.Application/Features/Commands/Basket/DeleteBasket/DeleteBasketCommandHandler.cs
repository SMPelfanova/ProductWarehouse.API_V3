using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;
public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBasketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var basketToDelete = _unitOfWork.Basket.GetBasketByUserId(request.userId);
        if (basketToDelete != null)
        {
            _unitOfWork.Basket.DeleteBasketLines(request.userId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
