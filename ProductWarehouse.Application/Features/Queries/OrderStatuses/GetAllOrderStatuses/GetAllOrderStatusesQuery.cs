using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public class GetAllOrderStatusesQuery() : IRequest<List<OrderStatusDto>>;