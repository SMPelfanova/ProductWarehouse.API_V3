﻿using MediatR;
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
		await _unitOfWork.Basket.DeleteBasketLinesAsync(request.UserId, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}