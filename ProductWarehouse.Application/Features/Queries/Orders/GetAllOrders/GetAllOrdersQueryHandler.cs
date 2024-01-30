using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        string[] includeProperties = { nameof(OrderDto.OrderDetails), nameof(OrderDto.Status) };
        var result = await _unitOfWork.Orders.GetAllAsync(includeProperties);
        var mapper = _mapper.Map<List<OrderDto>>(result);

        return mapper;
    }
}
