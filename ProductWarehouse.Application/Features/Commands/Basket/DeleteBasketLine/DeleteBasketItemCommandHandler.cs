using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;
public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketLineCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBasketItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteBasketLineCommand request, CancellationToken cancellationToken)
    {
        var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.basketLineId);
        if (basketLine == null)
        {
            throw new ArgumentException();
        }
        _unitOfWork.BasketLines.Delete(basketLine);
        await _unitOfWork.SaveChangesAsync();
    }
}
