using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
       var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
        if (order != null)
        {
            order.StatusId = request.StatusId;
            order.TotalAmount = request.TotalAmount;

            await _unitOfWork.SaveChangesAsync();
        }
    }
 
}