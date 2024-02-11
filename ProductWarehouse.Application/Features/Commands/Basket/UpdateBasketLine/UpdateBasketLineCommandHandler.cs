using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
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
        var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(request.BasketLine.Id);
        if (basketLine == null)
        {
            throw new Exception("Basket line not found");
        }

        var checkIfProductSizeAvailable = await _unitOfWork.Products.CheckQuantityInStockAsync(request.BasketLine.ProductId, request.BasketLine.SizeId);

        if (checkIfProductSizeAvailable >= request.BasketLine.Quantity)
        {
            basketLine.SizeId = request.BasketLine.SizeId;
            basketLine.Quantity = request.BasketLine.Quantity;
            _unitOfWork.BasketLines.Update(basketLine);
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentNullException("No available sizes");
        }
    }
}
