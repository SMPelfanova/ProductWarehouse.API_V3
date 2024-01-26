using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Brands;

namespace ProductWarehouse.API.Controllers;
public class BrandsController : BaseController
{
    public BrandsController(ILogger<BrandsController> logger, IMediator mediator, IMapper mapper)
    : base(logger, mediator, mapper)
    {
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult> GetBrands()
    {
        var result = await _mediator.Send(new GetAllBrandsQuery());

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetBrand(Guid id)
    {
        var product = await _mediator.Send(new GetBrandQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}
