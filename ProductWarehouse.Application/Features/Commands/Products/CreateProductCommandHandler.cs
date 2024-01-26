using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.Add(new Product
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            ProductSizes = new List<ProductSize> { new ProductSize
            {
                SizeId = request.SizeId,
                QuantityInStock = request.QuantityInStock
            }},
            BrandId = request.BrandId,
            ProductGroups = new List<ProductGroups>
            {
                new ProductGroups
                {
                    GroupId = request.GroupId
                }
            }
        });

        await _unitOfWork.SaveChangesAsync();

        return Guid.NewGuid();
    }
}
