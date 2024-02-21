using MediatR;
using ProductWarehouse.Application.Models.Order;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
public record GetAllOrdersQuery(Guid UserId) : IRequest<List<OrderDto>>;