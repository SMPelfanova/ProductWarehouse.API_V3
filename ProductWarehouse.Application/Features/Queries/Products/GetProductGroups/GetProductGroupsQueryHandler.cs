using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;
public class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, List<GroupDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Products.GetProductDetailsAsync(request.Id);
        if (result == null)
        {
            throw new Exception();
        }

        var mapper = _mapper.Map<List<GroupDto>>(result.ProductGroups);

        return mapper;
    }
}