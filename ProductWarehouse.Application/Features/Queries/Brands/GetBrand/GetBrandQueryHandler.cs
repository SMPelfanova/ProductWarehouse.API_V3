using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Brand;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
	{
		var brand = await _unitOfWork.Brands.GetByIdAsync(request.Id, cancellationToken);
		var result = _mapper.Map<BrandDto>(brand);

		return result;
	}
}