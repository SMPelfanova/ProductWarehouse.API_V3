using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;

public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand, BasketLineDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<BasketLineDto> Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.Id);

		_mapper.Map(request, basketLine);

		await SetBasketLinePrice(basketLine);

		_unitOfWork.BasketLines.Update(basketLine);
		await _unitOfWork.SaveChangesAsync();

		var basketLineDto = _mapper.Map<BasketLineDto>(basketLine);

		return basketLineDto;
	}

	private async Task SetBasketLinePrice(BasketLine basketLine)
	{
		var productDetails = await _unitOfWork.Products.GetByIdAsync(basketLine.ProductId);
		basketLine.Price = productDetails.Price;
	}
}