using AutoMapper;
using FluentValidation;
using MediatR;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsFilterDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<ProductsFilterDto> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
	{
		var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);

		if (!products.Any())
		{
			_logger.Information($"No products found for filter: minPrice={request.MinPrice} maxPrice={request.MaxPrice} size={request.Size}");
		}

		var productFilter = _mapper.Map<ProductsFilterDto>(products);

		productFilter.Products = productFilter.Products
			.Where(x => (request.MinPrice == 0 || x.Price >= request.MinPrice))
			.Where(x => (request.MaxPrice == 0 || x.Price <= request.MaxPrice))
			.Where(x => (string.IsNullOrEmpty(request.Size) || x.Sizes.Any(s => s.Name.ToLowerInvariant() == request.Size.ToLowerInvariant()))).ToList();

		if (!string.IsNullOrEmpty(request.Highlight))
		{
			productFilter.Products.ForEach(
				product => product.Description = product.Description.HighlightKeywords(request.Highlight));
		}

		return productFilter;
	}
}