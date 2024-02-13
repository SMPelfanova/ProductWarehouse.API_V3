using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

public class GetProductSizesQueryHandler : IRequestHandler<GetProductSizesQuery, List<SizeDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public GetProductSizesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<List<SizeDto>> Handle(GetProductSizesQuery request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id);
		if (product == null)
		{
			_logger.Warning($"No product found with id:{request.Id}");
			throw new ProductNotFoundException($"No product found with id:{request.Id}");
		}

		var result = _mapper.Map<List<SizeDto>>(product.ProductSizes);

		return result;
	}
}