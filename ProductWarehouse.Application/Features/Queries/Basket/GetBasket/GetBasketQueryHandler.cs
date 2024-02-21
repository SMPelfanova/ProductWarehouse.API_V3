using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Basket;

namespace ProductWarehouse.Application.Features.Queries.Basket.GetBasket;

public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
	{
		var basket = await _unitOfWork.Basket.GetBasketByUserIdAsync(request.UserId);
		var result = _mapper.Map<BasketDto>(basket);

		return result;
	}
}