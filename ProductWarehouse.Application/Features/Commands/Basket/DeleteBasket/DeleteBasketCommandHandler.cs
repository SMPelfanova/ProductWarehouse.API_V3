using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Basket.DeleteBasket;

public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public DeleteBasketCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
	{
		var basketToDelete = _unitOfWork.Basket.GetBasketByUserId(request.userId);
		if (basketToDelete == null)
		{
			_logger.Error($"No basket found for userId: {request.userId}");
			throw new BasketNotFoundException($"No basket found for userId: {request.userId}");
		}

		_unitOfWork.Basket.DeleteBasketLines(request.userId);
		await _unitOfWork.SaveChangesAsync();
	}
}