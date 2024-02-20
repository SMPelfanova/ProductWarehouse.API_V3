using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{

		var product = _mapper.Map<Product>(request);
		var addedProduct = await _unitOfWork.Products.Add(product);

		await _unitOfWork.SaveChangesAsync();

		return addedProduct.Id;
	}
}