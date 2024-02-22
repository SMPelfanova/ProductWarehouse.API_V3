using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProduct;

public class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteProductSizeCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id, cancellationToken);
		product.IsDeleted = true;
		await _unitOfWork.Products.UpdateAsync(product, cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}