using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;
using System.Threading;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;

public class AddBasketLineCommandHandler : IRequestHandler<AddBasketLineCommand, BasketLineDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public AddBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<BasketLineDto> Handle(AddBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLineRequest = _mapper.Map<BasketLine>(request);
		var basket = await _unitOfWork.Basket.GetBasketByUserIdAsync(request.UserId, cancellationToken);
		basketLineRequest.BasketId = basket.Id;

		await SetBasketLinePrice(basketLineRequest, cancellationToken);

		var basketLine = await _unitOfWork.BasketLines.AddAsync(basketLineRequest, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var basketDto = _mapper.Map<BasketLineDto>(basketLine);
		return basketDto;
	}

	private async Task SetBasketLinePrice(BasketLine basketLine, CancellationToken cancellationToken)
	{
		var productDetails = await _unitOfWork.Products.GetByIdAsync(basketLine.ProductId, cancellationToken);
		basketLine.Price = productDetails.Price;
	}
}