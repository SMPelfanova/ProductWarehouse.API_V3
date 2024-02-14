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
/// Controller for managing product related operations.
/// </summary>
public class ProductsController : BaseController
{
	/// <summary>
	/// Get all products.
	/// </summary>
	/// <returns>List of products.</returns>
	/// <response code="200">Returns list of products</response>
	[HttpGet]
	public async Task<IActionResult> GetProducts(
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var result = await mediator.Send(new GetAllProductsQuery());

		if (!result.Products.Any())
		{
			return NotFound();
		}

		var products = mapper.Map<List<ProductResponse>>(result.Products);

		return Ok(products);
	}

	/// <summary>
	/// Get products based on filter criteria.
	/// </summary>
	/// <param name="productsFilter">Filter criteria.</param>
	/// <returns>Filtered products.</returns>
	/// <response code="200">Returns filtered products</response>
	[HttpGet("filter")]
	public async Task<IActionResult> GetProducts(
		[FromQuery] FilterProductsRequest productsFilter,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var productsQueryMap = mapper.Map<GetAllProductsQuery>(productsFilter);
		var result = await mediator.Send(productsQueryMap);
		if (!result.Products.Any())
		{
			return NotFound();
		}

		var response = mapper.Map<ProductFilterResponse>(result);

		return Ok(response);
	}

	/// <summary>
	/// Retrieves a product by its ID.
	/// </summary>
	/// <param name="id">The ID of the product.</param>
	/// <returns>The product with the specified ID.</returns>
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

	/// <summary>
	/// Creates a new product.
	/// </summary>
	/// <param name="request">The request containing the product details.</param>
	/// <returns>The newly created product.</returns>
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

	/// <summary>
	/// Updates an existing product.
	/// </summary>
	/// <param name="request">The request containing the updated product details.</param>
	/// <returns>No content if the update is successful.</returns>
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

	/// <summary>
	/// Deletes a product by its ID.
	/// </summary>
	/// <param name="id">The ID of the product to delete.</param>
	/// <returns>No content if the deletion is successful.</returns>
	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeleteProduct(
		Guid id,
		[FromServices] IMediator mediator)
	{
		await mediator.Send(new DeleteProductCommand(id));
		return NoContent();
	}
}