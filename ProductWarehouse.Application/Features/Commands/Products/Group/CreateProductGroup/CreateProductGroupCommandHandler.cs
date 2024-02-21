using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, ProductGroupDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateProductGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductGroupDto> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);

		var productGroup = _mapper.Map<ProductGroups>(request);
		product.ProductGroups.Add(productGroup);
		await _unitOfWork.SaveChangesAsync();

		var productGroupDto = _mapper.Map<ProductGroupDto>(productGroup);

		return productGroupDto;
	}
}