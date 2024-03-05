using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		Product? product = _mapper.Map<Product>(request);

		//try
		//{
			_unitOfWork.BeginTransaction();
			product = await _unitOfWork.Products.AddAsync(product);
			throw new DatabaseException("error");
			_unitOfWork.CommitTransaction();

			var productDto = _mapper.Map<ProductDto>(product);

			return productDto;
		//}
		//catch (DatabaseException)
		//{
		//	//_unitOfWork.RollbackTransaction();
		//	throw new DatabaseException(MessageConstants.GeneralErrorMessage);
		//}
	}
}