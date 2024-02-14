using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;

public class AddBasketLineCommandHandler : IRequestHandler<AddBasketLineCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public AddBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<Guid> Handle(AddBasketLineCommand request, CancellationToken cancellationToken)
	{
		var basket = _unitOfWork.Basket.GetBasketByUserId(request.UserId);
		if (basket == null)
		{
			_logger.Error($"No basket found for user: {request.UserId}");
			throw new BasketNotFoundException($"No basket found for user: {request.UserId}");
		}

		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(request.ProductId, request.SizeId);
		if (availableSizes >= request.Quantity)
		{

			var basketLine = _mapper.Map<BasketLine>(request);
			basketLine.BasketId = basket.Id;
			await _unitOfWork.BasketLines.Add(basketLine);

			await _unitOfWork.SaveChangesAsync();

			return basket.Id;
		}
		else
		{
			_logger.Warning($"No available sizes for ProductId: {request.ProductId}. Sizes requested: {request.Quantity}, but available count is: {availableSizes}");
			return Guid.Empty;
		}
	}
}