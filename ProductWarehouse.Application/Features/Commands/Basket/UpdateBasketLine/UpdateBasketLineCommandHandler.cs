using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;

public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateBasketLineCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.Id);
	
		basketLine.Id = request.Id;
		basketLine.SizeId = request.SizeId;
		basketLine.Quantity = request.Quantity;
		basketLine.Price = request.Price;

		_unitOfWork.BasketLines.Update(basketLine);
		await _unitOfWork.SaveChangesAsync();
	}
}