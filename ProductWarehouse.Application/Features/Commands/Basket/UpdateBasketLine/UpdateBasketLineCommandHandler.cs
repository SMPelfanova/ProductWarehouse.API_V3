using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;

public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public UpdateBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<Guid> Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.BasketLine.Id);
		if (basketLine == null)
		{
			_logger.Error($"No basket found with id: {request.BasketLine.Id}");
			throw new BasketNotFoundException($"No basket found with id: {request.BasketLine.Id}");
		}
		if (request.BasketLine.Quantity == 0)
		{
			_unitOfWork.BasketLines.Delete(basketLine);
			await _unitOfWork.SaveChangesAsync();

			return Guid.Empty;
		}

		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(request.BasketLine.ProductId, request.BasketLine.SizeId);

		if (availableSizes >= request.BasketLine.Quantity)
		{
			var updateBasketLine = _mapper.Map<BasketLine>(request.BasketLine);
			_unitOfWork.BasketLines.Update(updateBasketLine);
			await _unitOfWork.SaveChangesAsync();

			return basketLine.Id;
		}
		else
		{
			_logger.Warning($"No available sizes for ProductId: {request.BasketLine.ProductId}. Sizes requested: {request.BasketLine.Quantity}, but available count is: {availableSizes}");
			return Guid.Empty;
		}
	}
}