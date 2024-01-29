using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public record UpdateOrderCommand(Guid Id, OrderDto order) : IRequest;