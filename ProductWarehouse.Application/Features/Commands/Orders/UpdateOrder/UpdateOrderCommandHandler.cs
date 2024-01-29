using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{

    public UpdateOrderCommandHandler()
    {
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
    }
 
}