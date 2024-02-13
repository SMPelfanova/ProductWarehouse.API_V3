using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products.Size.UpdateProductSize;

public class UpdateProductSizeCommandHandler : IRequestHandler<UpdateProductSizeCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public UpdateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
	{
		var size = await _unitOfWork.Sizes.GetByIdAsync(request.sizeId);

		if (size == null)
		{
			_logger.Error($"No size found with id: {request.sizeId}");
			throw new SizeNotFoundException($"No size found with id: {request.sizeId}");
		}
		var map = _mapper.Map<ProductSize>(request);

		_unitOfWork.ProductSizes.Update(map);
		await _unitOfWork.SaveChangesAsync();
	}
}