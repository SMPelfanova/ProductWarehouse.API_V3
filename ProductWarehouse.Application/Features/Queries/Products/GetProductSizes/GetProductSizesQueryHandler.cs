using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

public class GetProductSizesQueryHandler : IRequestHandler<GetProductSizesQuery, List<ProductSizeDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetProductSizesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<List<ProductSizeDto>> Handle(GetProductSizesQuery request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id, cancellationToken);
		var result = _mapper.Map<List<ProductSizeDto>>(product.ProductSizes);

		return result;
	}
}