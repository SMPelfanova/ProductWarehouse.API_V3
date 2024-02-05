using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;
public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
        var group = await _unitOfWork.Group.GetByIdAsync(request.GroupId);

        if (product != null && group != null && !product.ProductGroups.Any(x=>x.Group.Id == group.Id))
        {
            product.ProductGroups.Add(new ProductGroups
            {
                ProductId = request.ProductId,
                GroupId = request.GroupId,
            });
        }

        await _unitOfWork.SaveChangesAsync();

        return request.ProductId;
    }
}
