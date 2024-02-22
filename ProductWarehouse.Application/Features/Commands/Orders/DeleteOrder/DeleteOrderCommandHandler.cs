using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		var order = await _unitOfWork.Orders.GetByIdAsync(request.Id, cancellationToken);

		order.IsDeleted = true;
		await _unitOfWork.Orders.UpdateAsync(order, cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}