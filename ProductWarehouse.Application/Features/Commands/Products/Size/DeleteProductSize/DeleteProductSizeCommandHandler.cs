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
		await _unitOfWork.Products.DeleteProductSizeAsync(request.ProductId, request.SizeId, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}