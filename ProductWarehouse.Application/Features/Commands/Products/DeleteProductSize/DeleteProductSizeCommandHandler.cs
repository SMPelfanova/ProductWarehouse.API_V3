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
        var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
        var group = await _unitOfWork.Sizes.GetByIdAsync(request.SizeId);

        _unitOfWork.Products.DeleteProductSizes(request.ProductId, request.SizeId);

        await _unitOfWork.SaveChangesAsync();
    }
}
