using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public CreateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<Guid> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);
		
		if (!product.ProductSizes.Any(x => x.SizeId == request.SizeId))
		{
			var productSize = _mapper.Map<ProductSize>(request);
			await _unitOfWork.ProductSizes.Add(productSize);

			await _unitOfWork.SaveChangesAsync();
		}

		return request.ProductId;
	}
}