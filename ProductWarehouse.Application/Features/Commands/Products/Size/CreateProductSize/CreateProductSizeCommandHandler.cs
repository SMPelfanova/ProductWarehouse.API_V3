using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public CreateProductSizeCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<Guid> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);
		if (product == null)
		{
			_logger.Error($"No product found with id: {request.ProductId}");
			throw new ProductNotFoundException($"No product found with id: {request.ProductId}");
		}

		if (!product.ProductSizes.Any(x => x.SizeId == request.SizeId))
		{
			await _unitOfWork.ProductSizes.Add(new ProductSize
			{
				ProductId = request.ProductId,
				SizeId = request.SizeId,
				QuantityInStock = request.QuantityInStock
			});

			await _unitOfWork.SaveChangesAsync();
		}

		return request.ProductId;
	}
}