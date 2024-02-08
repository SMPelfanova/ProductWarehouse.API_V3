using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Basket.CreateBasketItem;
public class AddBasketLineCommandHandler : IRequestHandler<AddBasketLineCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddBasketLineCommand request, CancellationToken cancellationToken)
    {
        var basket = _unitOfWork.Basket.GetBasketByUserId(request.UserId);
        if (basket != null)
        {
            _unitOfWork.Basket.AddBasketLine(request.UserId, new BasketLine
            {
                BasketId = basket.Id,
                SizeId = request.BasketLine.SizeId,
                ProductId = request.BasketLine.ProductId,
                Quantity = request.BasketLine.Quantity,
                Price = request.BasketLine.Price
            });
            await _unitOfWork.SaveChangesAsync();

            return basket.Id;
        }

        throw new ArgumentNullException(nameof(request));
    }
}
