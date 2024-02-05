using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
public class GetProductSizesQueryHandler : IRequestHandler<GetProductSizesQuery, SizeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductSizesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SizeDto> Handle(GetProductSizesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Products.GetByIdAsync(request.Id);
        if (result == null)
        {
            throw new Exception();
        }

        var mapper = _mapper.Map<SizeDto>(result.ProductSizes);

        return mapper;
    }
}