using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id, cancellationToken);
		
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
		try
		{
			await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
		}
		catch
		{
			_unitOfWork.Rollback();
		}

		var productDto = _mapper.Map<ProductDto>(product);

		return productDto;
	}
}