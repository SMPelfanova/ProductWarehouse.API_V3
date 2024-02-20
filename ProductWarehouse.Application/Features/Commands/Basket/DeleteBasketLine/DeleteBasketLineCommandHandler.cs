using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasketLine;

public class DeleteBasketLineCommandHandler : IRequestHandler<DeleteBasketLineCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteBasketLineCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(DeleteBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.basketLineId);
		_unitOfWork.BasketLines.Delete(basketLine);
		await _unitOfWork.SaveChangesAsync();
	}
}