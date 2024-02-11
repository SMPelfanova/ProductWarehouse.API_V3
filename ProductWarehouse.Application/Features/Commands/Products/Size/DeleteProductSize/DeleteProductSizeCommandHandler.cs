using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
public class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductSizeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductSizeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);
        var productSizeToDelete = product.ProductSizes.FirstOrDefault(x => x.SizeId == request.SizeId);
        if (productSizeToDelete != null)
        {
            _unitOfWork.ProductSizes.Delete(productSizeToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

    }
}
