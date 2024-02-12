using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class PartialUpdateOrderCommandHandler : IRequestHandler<PartialUpdateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public PartialUpdateOrderCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task Handle(PartialUpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

		if (order == null)
		{
			_logger.Error($"No order found with id: {request.Id}");
			throw new OrderNotFoundException($"No order found with id: {request.Id}");
		}

		var partialUpdate = new PartialUpdateOrderRequest();
        request.PatchDocument.ApplyTo(partialUpdate);

        if (partialUpdate.TotalAmount.HasValue)
        {
            order.TotalAmount = partialUpdate.TotalAmount.Value;
        }
        if (partialUpdate.StatusId.HasValue)
        {
            order.StatusId = partialUpdate.StatusId.Value;
        }

        await _unitOfWork.SaveChangesAsync();
    }
}