using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products.Size.UpdateProductSize;
public class UpdateProductSizeCommandHandler : IRequestHandler<UpdateProductSizeCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
    {
        var map = _mapper.Map<ProductSize>(request);
      
        _unitOfWork.ProductSizes.Update(map);
        await _unitOfWork.SaveChangesAsync();
    }
}
