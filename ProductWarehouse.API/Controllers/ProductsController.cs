using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.QueryParameters;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.API.Controllers
{
    /// <summary>
    /// Controller for managing product-related operations.
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>List of products.</returns>
        /// <response code="200">Returns list of products</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetProducts()
        {
            var result = await _mediator.Send(new ProductsQuery());
            if (result == null || !result.Products.Any())
            {
                return NotFound();
            }

            return Ok(result.Products);
        }

        /// <summary>
        /// Get products based on filter criteria.
        /// </summary>
        /// <param name="productsFilter">Filter criteria.</param>
        /// <returns>Filtered products.</returns>
        /// <response code="200">Returns filtered products</response>
        [HttpGet("filter")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductFilterResponse), 200)]
        public async Task<ActionResult> GetProducts([FromQuery] ProductsFilter productsFilter)
        {
            var result = await _mediator.Send(new ProductsQuery { 
                MinPrice = productsFilter.MinPrice,
                MaxPrice = productsFilter.MaxPrice,
                Highlight = productsFilter.Highlight,
                Size = productsFilter.Size
            });

            return Ok(result);
        }
     
    }
}
