using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Products.Add(new Product
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
    }
}
