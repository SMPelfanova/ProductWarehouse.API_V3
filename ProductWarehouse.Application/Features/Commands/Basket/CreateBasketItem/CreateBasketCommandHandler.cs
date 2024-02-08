using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _unitOfWork.Basket.GetBasketByUserId(request.UserId);
        if (basket == null)
        {
            var newBasket = new Domain.Entities.Basket { UserId = request.UserId, BasketLines = new List<BasketLine>() };
            var id = await _unitOfWork.Basket.Add(newBasket);
            foreach (var item in request.Items)
            {
                newBasket.BasketLines.Add(new BasketLine
                {
                    BasketId = id,
                    SizeId = item.SizeId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }
            await _unitOfWork.SaveChangesAsync();

            return newBasket.Id;
        }
        return basket.Id;
    }
}
