using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetAllGroups;

public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, List<GroupDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
    {
        var groups = await _unitOfWork.Group.GetAllAsync();
        var result = _mapper.Map<List<GroupDto>>(groups);

        return result;
    }
}
