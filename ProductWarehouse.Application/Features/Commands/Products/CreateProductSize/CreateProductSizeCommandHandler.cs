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
        var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
        var size = await _unitOfWork.Sizes.GetByIdAsync(request.SizeId);

        if (product != null && size != null && !product.ProductSizes.Any(x => x.Size.Id == size.Id))
        {
            product.ProductSizes.Add(new ProductSize
            {
                ProductId = request.ProductId,
                SizeId = request.SizeId,
            });
        }

        await _unitOfWork.SaveChangesAsync();

        return request.ProductId;
    }
}
