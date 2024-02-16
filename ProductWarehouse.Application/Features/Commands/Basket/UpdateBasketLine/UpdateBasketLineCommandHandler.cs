using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;

public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Guid> Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.Id);
	
		basketLine.Id = request.Id;
		basketLine.SizeId = request.SizeId;
		basketLine.Quantity = request.Quantity;
		basketLine.Price = request.Price;

		_unitOfWork.BasketLines.Update(basketLine);
		await _unitOfWork.SaveChangesAsync();

		return basketLine.Id;
	}
}