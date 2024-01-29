using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Orders.DeleteOrder;
public record DeleteOrderCommand(Guid Id) : IRequest;

