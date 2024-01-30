using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;
public class GetAllOrderStatusesQueryHandler : IRequestHandler<GetAllOrderStatusesQuery, List<OrderStatusDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllOrderStatusesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<OrderStatusDto>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.OrdersStatuses.GetAllAsync();
        var mapper = _mapper.Map<List<OrderStatusDto>>(result);

        return mapper;
    }
}
