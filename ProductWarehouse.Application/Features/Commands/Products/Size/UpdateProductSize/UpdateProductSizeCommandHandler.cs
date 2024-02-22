using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.Size.UpdateProductSize;

public class UpdateProductSizeCommandHandler : IRequestHandler<UpdateProductSizeCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
	{
		var productSize = await _unitOfWork.Products.GetProductSizeAsync(request.ProductId, request.SizeId, cancellationToken);

		_mapper.Map(request, productSize);

		await _unitOfWork.ProductSizes.UpdateAsync(productSize, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);
	}
}