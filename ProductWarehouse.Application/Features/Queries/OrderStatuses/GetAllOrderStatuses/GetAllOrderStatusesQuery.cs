using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public record GetAllOrderStatusesQuery() : IRequest<List<OrderStatusDto>>;