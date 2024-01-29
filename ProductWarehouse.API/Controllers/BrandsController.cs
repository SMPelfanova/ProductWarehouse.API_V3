using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
using ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-brands-related operations.
/// </summary>
//[Route("api/products/{id:guid}/brand")]
public class BrandsController : BaseController
{
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> Brands([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllBrandsQuery());

        return Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Brands([FromServices] IMediator mediator, Guid brandId)
    {
        var product = await mediator.Send(new GetBrandQuery(brandId));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}
