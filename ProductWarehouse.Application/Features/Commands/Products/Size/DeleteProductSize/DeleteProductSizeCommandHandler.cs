using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;

public class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductSizeCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public DeleteProductSizeCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);
		if (product == null)
		{
			_logger.Error($"No product found with id: {request.ProductId}");
			throw new ProductNotFoundException($"No product found with id: {request.ProductId}");
		}

		var productSizeToDelete = product.ProductSizes.FirstOrDefault(x => x.SizeId == request.SizeId);
		if (productSizeToDelete != null)
		{
			_unitOfWork.ProductSizes.Delete(productSizeToDelete);

			await _unitOfWork.SaveChangesAsync();
		}
	}
}