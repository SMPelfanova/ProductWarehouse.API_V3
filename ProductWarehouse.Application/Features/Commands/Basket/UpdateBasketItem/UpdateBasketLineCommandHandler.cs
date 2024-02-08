using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketItem;
public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBasketLineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.Basket.UpdateBasketLine(request.UserId, new Domain.Entities.BasketLine
        {
            SizeId = request.BasketLine.SizeId,
            ProductId = request.BasketLine.ProductId,
            Price = request.BasketLine.Price,
            Quantity = request.BasketLine.Quantity
        });
        await _unitOfWork.SaveChangesAsync();
    }
}
