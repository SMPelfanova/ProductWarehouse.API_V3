using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.GetProduct;
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
       var result = await _productRepository.GetByIdAsync(request.Id);

        return _mapper.Map<ProductDto>(result);
    }
}
