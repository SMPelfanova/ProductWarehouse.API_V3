using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.DeleteProduct;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
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

        if (!products.Any())
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
        [FromQuery] FilterProductsRequest productsFilter,
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper)
    {
        var productsQueryMap = mapper.Map<GetAllProductsQuery>(productsFilter);

        var result = await mediator.Send(productsQueryMap);

        var response = mapper.Map<ProductFilterResponse>(result);

        if (!response.Products.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(
        Guid id,
        [FromServices] IMediator mediator)
    {
        var product = await mediator.Send(new GetProductQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductRequest request,
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper)
    {
        if (request == null)
        {
            return BadRequest("Request body is null");
        }

        var command = mapper.Map<CreateProductCommand>(request);

        var productId = await mediator.Send(command);

        return CreatedAtAction(nameof(GetProduct), new { id = productId }, request);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(
        [FromBody] UpdateProductRequest request,
        [FromServices] IMediator mediator,
        [FromServices] IMapper mapper)
    {
        var command = mapper.Map<UpdateProductCommand>(request);
        await mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(
        Guid id,
        [FromServices] IMediator mediator)
    {
        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}
