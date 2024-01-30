using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public record GetOrderStatusQuery(Guid Id) : IRequest<OrderStatusDto>;