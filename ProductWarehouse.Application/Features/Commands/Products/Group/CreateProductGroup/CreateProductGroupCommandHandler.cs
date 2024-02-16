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
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public CreateProductGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<Guid> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);

		if (!product.ProductGroups.Any(x => x.Group.Id == request.GroupId))
		{
			var productGroup = _mapper.Map<ProductGroups>(request);
			product.ProductGroups.Add(productGroup);
			await _unitOfWork.SaveChangesAsync();
		}

		return request.ProductId;
	}
}