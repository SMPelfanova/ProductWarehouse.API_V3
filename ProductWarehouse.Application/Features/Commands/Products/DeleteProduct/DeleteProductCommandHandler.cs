using MediatR;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

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
		try
		{
			_unitOfWork.BeginTransaction();
			await _unitOfWork.Products.UpdateProductIsDeletedAsync(product.Id);
			_unitOfWork.CommitTransaction();
		}
		catch (DatabaseException)
		{
			_unitOfWork.RollbackTransaction();
			throw new DatabaseException(MessageConstants.GeneralErrorMessage);
		}
	}
}