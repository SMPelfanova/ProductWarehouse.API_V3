using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.GetProduct;
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id);
        if (product == null)
        {
            _logger.Warning($"No product found with id:{request.Id}");
            throw new ProductNotFoundException($"No product found with id:{request.Id}");
        }

        var result = _mapper.Map<ProductDto>(product);

        return result;
    }
}
