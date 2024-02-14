using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
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
		var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.Id);
		if (basketLine == null)
		{
			_logger.Error($"No basket found with id: {request.Id}");
			throw new BasketNotFoundException($"No basket found with id: {request.Id}");
		}

		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(request.ProductId, request.SizeId);

		if (availableSizes >= request.Quantity)
		{
			basketLine.Id = request.Id;
			basketLine.SizeId = request.SizeId;
			basketLine.Quantity = request.Quantity;
			basketLine.Price = request.Price;

			_unitOfWork.BasketLines.Update(basketLine);

			await _unitOfWork.SaveChangesAsync();

			return basketLine.Id;
		}
		else
		{
			_logger.Warning($"No available sizes for ProductId: {request.ProductId}. Sizes requested: {request.Quantity}, but available count is: {availableSizes}");
			return Guid.Empty;
		}
	}
}