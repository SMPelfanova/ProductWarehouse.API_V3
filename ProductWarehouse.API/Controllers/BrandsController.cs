using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
using ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-brands-related operations.
/// </summary>
public class BrandsController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetBrands([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllBrandsQuery());

        if (result == null || !result.Any())
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBrand([FromServices] IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetBrandQuery(id));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

}
