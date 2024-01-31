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
        var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
        order.IsDeleted = true;

        _unitOfWork.Orders.Update(order);

        await _unitOfWork.SaveChangesAsync();
    }
}
