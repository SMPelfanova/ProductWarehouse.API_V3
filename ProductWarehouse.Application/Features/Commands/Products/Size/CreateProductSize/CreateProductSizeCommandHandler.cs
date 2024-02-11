using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;
public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetProductDetailsAsync(request.ProductId);

        if (product != null && !product.ProductSizes.Any(x => x.Size.Id == request.SizeId))
        {
             await _unitOfWork.ProductSizes.Add(new ProductSize
            {
                ProductId = request.ProductId,
                SizeId = request.SizeId,
                QuantityInStock = request.QuantityInStock
            });

            await _unitOfWork.SaveChangesAsync();
        }

        return request.ProductId;
    }
}
