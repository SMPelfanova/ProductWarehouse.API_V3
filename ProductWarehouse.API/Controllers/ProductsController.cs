using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Exceptions;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using System.Net;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-related operations.
/// </summary>
public class ProductsController : BaseController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="mediator">The mediator.</param>
    /// <param name="mapper">The mapper.</param>
    public ProductsController(ILogger<ProductsController> logger, IMediator mediator, IMapper mapper)
         : base(logger, mediator, mapper)
    {
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>List of products.</returns>
    /// <response code="200">Returns list of products</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetProducts()
    {
        var result = await _mediator.Send(new ProductsQuery());
        var products = _mapper.Map<IEnumerable<ProductResponse>>(result.Products);
        if (products == null || !products.Any())
        {
            return NotFound();
        }


        return Ok(products);
    }

    /// <summary>
    /// Get products based on filter criteria.
    /// </summary>
    /// <param name="productsFilter">Filter criteria.</param>
    /// <returns>Filtered products.</returns>
    /// <response code="200">Returns filtered products</response>
    [HttpGet("filter")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ProductFilterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> GetProducts([FromQuery] FilterProductsRequest productsFilter)
    {
        try
        {
            var productsQueryMap = _mapper.Map<ProductsQuery>(productsFilter);
            var result = await _mediator.Send(productsQueryMap);
            var response = _mapper.Map<ProductFilterResponse>(result);

            if (response == null || !response.Products.Any())
            {
                return NotFound();
            }

            return Ok(response);
        }
        catch (ValidatorException ex)
        {
            var validationErrors = ex.Errors.Select(error => new
            {
                Property = error.PropertyName,
                Message = error.ErrorMessage
            });

            return BadRequest(new { Errors = validationErrors });
        }
    }
}
