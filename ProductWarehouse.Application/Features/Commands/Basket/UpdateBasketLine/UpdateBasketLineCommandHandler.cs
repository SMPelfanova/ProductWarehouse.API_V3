using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;
using System.Threading;

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
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.Id, cancellationToken);

		_mapper.Map(request, basketLine);

		await SetBasketLinePrice(basketLine, cancellationToken);

		await _unitOfWork.BasketLines.DeleteAsync(basketLine, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var basketLineDto = _mapper.Map<BasketLineDto>(basketLine);

		return basketLineDto;
	}

	private async Task SetBasketLinePrice(BasketLine basketLine, CancellationToken cancellationToken)
	{
		var productDetails = await _unitOfWork.Products.GetByIdAsync(basketLine.ProductId, cancellationToken);
		basketLine.Price = productDetails.Price;
	}
}