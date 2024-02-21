using MediatR;
using ProductWarehouse.Application.Models.Order;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public record GetOrderStatusQuery(Guid Id) : IRequest<OrderStatusDto>;