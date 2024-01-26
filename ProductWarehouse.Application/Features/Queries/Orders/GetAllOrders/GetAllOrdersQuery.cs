using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
public record GetAllOrdersQuery() : IRequest<List<OrderDto>>;
