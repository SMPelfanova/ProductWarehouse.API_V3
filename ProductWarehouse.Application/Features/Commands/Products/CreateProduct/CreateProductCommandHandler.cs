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
        var product = new Product
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            BrandId = request.BrandId
        };

        if (request.Groups != null)
        {
            product.ProductGroups = new List<ProductGroups>();
            foreach(var group in request.Groups)
            {
                product.ProductGroups.Add(new ProductGroups
                {
                    GroupId = group.Id
                });
            }
        }
        if (request.Sizes != null)
        {
            product.ProductSizes = new List<ProductSize>();
            foreach (var size in request.Sizes)
            {
                product.ProductSizes.Add(new ProductSize
                {
                    SizeId = size.Id
                });
            }
        }
     
        await _unitOfWork.Products.Add(product);

        await _unitOfWork.SaveChangesAsync();
    }
}
