using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using Serilog;

namespace ProductWarehouse.Application.Features.Commands.Products;
public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;
    public CreateProductGroupCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
		_logger = logger;
    }
    public async Task<Guid> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);
		if (product == null)
		{
			_logger.Error($"No product found with id: {request.ProductId}");
			throw new ProductNotFoundException($"No product found with id: {request.ProductId}");
		}

		if (!product.ProductGroups.Any(x=>x.Group.Id == request.GroupId))
        {
            product.ProductGroups.Add(new ProductGroups
            {
                ProductId = request.ProductId,
                GroupId = request.GroupId,
            });
            await _unitOfWork.SaveChangesAsync();
        }

        return request.ProductId;
    }
}
