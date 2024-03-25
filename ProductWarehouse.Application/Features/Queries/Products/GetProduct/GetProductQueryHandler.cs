using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;

namespace ProductWarehouse.Application.Features.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id, cancellationToken);
		var result = _mapper.Map<ProductDto>(product);
		var sizes = await _unitOfWork.Sizes.GetAllAsync(cancellationToken);
		foreach (var size in sizes)
		{
			if (!result.Sizes.Where(s => s.Id == size.Id).Any())
			{
				result.Sizes.Add(new Models.Size.SizeDto
				{
					Id = size.Id,
					Name = size.Name,
					QuantityInStock = 0
				});
			}
		}

		return result;
	}
}