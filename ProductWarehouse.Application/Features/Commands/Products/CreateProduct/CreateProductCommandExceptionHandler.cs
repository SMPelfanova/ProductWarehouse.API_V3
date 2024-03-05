using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

namespace ProductWarehouse.Application.Features.Commands.Products.CreateProduct;
public class CreateProductCommandExceptionHandler : Interfaces.IRequestExceptionHandler<CreateProductCommand, ProductDto, DatabaseException>
{
	private readonly ILogger<CreateProductCommandExceptionHandler> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductCommandExceptionHandler(ILogger<CreateProductCommandExceptionHandler> logger, IUnitOfWork unitOfWork)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(CreateProductCommand request, DatabaseException exception, RequestExceptionHandlerState<ProductDto> state, CancellationToken cancellationToken)
	{
		_unitOfWork.RollbackTransaction();

		state.SetHandled(new ProductDto());
	}
}