using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProduct;
using ProductWarehouse.Application.Features.Queries.GetProduct;
using ProductWarehouse.Application.Features.Queries.GetProducts;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing product-related operations.
/// </summary>
public class ProductsController : BaseController
{
    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>List of products.</returns>
    /// <response code="200">Returns list of products</response>
    [HttpGet]
    [Produces("application/json")]
    public async Task<IActionResult> GetProducts(
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper)
    {
        var result = await mediator.Send(new GetAllProductsQuery());

        var products = mapper.Map<IEnumerable<ProductResponse>>(result.Products);

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
    public async Task<IActionResult> GetProducts(
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper,
        [FromQuery] FilterProductsRequest productsFilter)
    {
        var productsQueryMap = mapper.Map<GetAllProductsQuery>(productsFilter);

        var result = await mediator.Send(productsQueryMap);

        var response = mapper.Map<ProductFilterResponse>(result);

        if (response == null || !response.Products.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct([FromServices] IMediator mediator, Guid id)
    {
        var product = await mediator.Send(new GetProductQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromServices] IMediator mediator, CreateProductCommand command)
    {
        var productId = await mediator.Send(command);
        var createdResourcePath = Url.Action("api/products", new { id = productId });

        return CreatedAtAction(actionName: createdResourcePath, command);
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromServices] IMediator mediator, Guid id)
    {
        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}
