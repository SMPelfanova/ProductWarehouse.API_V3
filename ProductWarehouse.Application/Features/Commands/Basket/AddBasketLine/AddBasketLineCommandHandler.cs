using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;

public class AddBasketLineCommandHandler : IRequestHandler<AddBasketLineCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public AddBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Guid> Handle(AddBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = _mapper.Map<BasketLine>(request);
		var basket = await _unitOfWork.Basket.GetBasketByUserIdAsync(request.UserId);

		basketLine.BasketId = basket.Id;
		await _unitOfWork.BasketLines.Add(basketLine);
		await _unitOfWork.SaveChangesAsync();

		return basket.Id;
	}
}