using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

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
		var basket = await _unitOfWork.Basket.GetBasketByUserIdAsync(request.UserId);
		basketLineRequest.BasketId = basket.Id;

		await SetBasketLinePrice(basketLineRequest);

		var basketLine = await _unitOfWork.BasketLines.Add(basketLineRequest);
		await _unitOfWork.SaveChangesAsync();

		var basketDto = _mapper.Map<BasketLineDto>(basketLine);
		return basketDto;
	}

	private async Task SetBasketLinePrice(BasketLine basketLine)
	{
		var productDetails = await _unitOfWork.Products.GetByIdAsync(basketLine.ProductId);
		basketLine.Price = productDetails.Price;
	}
}