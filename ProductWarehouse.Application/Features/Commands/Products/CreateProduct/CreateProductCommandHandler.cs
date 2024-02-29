﻿using AutoMapper;
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
		Product? product;
		
		try
		{
			product = _mapper.Map<Product>(request);

			_unitOfWork.BeginTransaction();

			var addedProduct = await _unitOfWork.Products.AddAsync(product, cancellationToken);

			await _unitOfWork.SaveChangesAsync(cancellationToken);
			var productDto = _mapper.Map<ProductDto>(addedProduct);

			return productDto;
		}
		catch (Exception)
		{
			_unitOfWork.Rollback();
			throw new DatabaseException(MessageConstants.GeneralErrorMessage);
		}
	}
}