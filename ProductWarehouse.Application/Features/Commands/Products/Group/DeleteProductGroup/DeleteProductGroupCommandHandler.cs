using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;

public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILogger _logger;

	public DeleteProductGroupCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
		if (product == null)
		{
			_logger.Error($"No product found with id: {request.ProductId}");
			throw new ProductNotFoundException($"No product found with id: {request.ProductId}");
		}

		var group = await _unitOfWork.Group.GetByIdAsync(request.GroupId);
		if (group == null)
		{
			_logger.Error($"No group found with id: {request.GroupId}");
			throw new GroupNotFoundException($"No group found with id: {request.GroupId}");
		}

		_unitOfWork.Products.DeleteProductGroup(request.ProductId, request.GroupId);
		await _unitOfWork.SaveChangesAsync();
	}
}