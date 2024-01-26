using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetOrder;
public record GetOrderQuery(Guid Id) : IRequest<OrderDto>;