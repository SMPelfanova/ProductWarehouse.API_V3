using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
		if (order == null)
		{
			_logger.Error($"No order found with id: {request.Id}");
			throw new OrderNotFoundException($"No order found with id: {request.Id}");
		}
		order.IsDeleted = true;
		_unitOfWork.Orders.Update(order);

		await _unitOfWork.SaveChangesAsync();
	}
}