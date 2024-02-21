using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id);

		_mapper.Map(request, product);

		product.ProductSizes.Clear();
		foreach (var sizeDto in request.Sizes)
		{
			product.ProductSizes.Add(new ProductSize
			{
				SizeId = sizeDto.Id,
				QuantityInStock = sizeDto.QuantityInStock
			});
		}

		product.ProductGroups.Clear();
		foreach (var groupDto in request.Groups)
		{
			product.ProductGroups.Add(new ProductGroups
			{
				GroupId = groupDto.Id
			});
		}

		_unitOfWork.Products.Update(product);
		await _unitOfWork.SaveChangesAsync();
	}
}