using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.Basket.GetBasket;
public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = _unitOfWork.Basket.GetBasketByUserId(request.UserId);
        if (basket == null)
        {
            _logger.Error($"No basket found for user: {request.UserId}");
            throw new BasketNotFoundException($"No basket found for user: {request.UserId}");
        }

        var result = _mapper.Map<BasketDto>(basket);

        return result;
    }
}
