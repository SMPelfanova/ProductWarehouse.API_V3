using MediatR;
using ProductWarehouse.Application.Models.Order;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public record GetAllOrderStatusesQuery() : IRequest<List<OrderStatusDto>>;