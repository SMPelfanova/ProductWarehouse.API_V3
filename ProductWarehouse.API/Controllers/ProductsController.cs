using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Requests.Base;
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
		[FromRoute] BaseEmptyRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper)
	{
		var query = mapper.Map<GetAllProductsQuery>(request);
		var result = await mediator.Send(query);

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
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var query = mapper.Map<GetProductQuery>(request);
		var product = await mediator.Send(query);

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
		[FromRoute] BaseRequestId request,
		[FromServices] IMapper mapper,
		[FromServices] IMediator mediator)
	{
		var command = mapper.Map<DeleteProductCommand>(request);
		await mediator.Send(command);

		return NoContent();
	}
}