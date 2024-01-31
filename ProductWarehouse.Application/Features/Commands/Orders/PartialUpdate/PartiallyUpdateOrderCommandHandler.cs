using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class PartialUpdateOrderCommandHandler : IRequestHandler<PartialUpdateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PartialUpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(PartialUpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);

        if (order == null)
        {
            return;
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