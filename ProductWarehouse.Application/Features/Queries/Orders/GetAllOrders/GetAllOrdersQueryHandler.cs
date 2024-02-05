using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        string[] includeProperties = { nameof(OrderDto.OrderDetails), nameof(OrderDto.Status) };
        var result = await _unitOfWork.Orders.GetAllAsync(includeProperties);
        var orders = _mapper.Map<List<OrderDto>>(result);
        if (orders.Count() <= 0)
        {
            _logger.Information($"No orders found.");
            return new List<OrderDto>();
        }

        return orders;
    }
}
