using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public record UpdateOrderCommand(Guid Id, Guid StatusId, decimal TotalAmount) : IRequest;
