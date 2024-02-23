using MediatR;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;

public class PartialUpdateOrderCommandHandler : IRequestHandler<PartialUpdateOrderCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public PartialUpdateOrderCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(PartialUpdateOrderCommand request, CancellationToken cancellationToken)
	{
		var order = await _unitOfWork.Orders.GetByIdAsync(request.Id, cancellationToken);

		var partialUpdate = new PartialUpdateOrderCommandRequest();
		request.PatchDocument.ApplyTo(partialUpdate);

		if (partialUpdate.TotalAmount.HasValue)
		{
			order.TotalAmount = partialUpdate.TotalAmount.Value;
		}
		if (partialUpdate.StatusId.HasValue)
		{
			order.StatusId = partialUpdate.StatusId.Value;
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}