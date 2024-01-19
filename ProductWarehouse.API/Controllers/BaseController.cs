using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly ILogger<BaseController> _logger;
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;

    public BaseController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }
}
