using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;
        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>List of products.</returns>
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
        /// <param name="searchFilter">Filter criteria.</param>
        /// <returns>Filtered products.</returns>
        [HttpGet("filter")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProductFilterResponse), 200)]
        public async Task<ActionResult> GetProducts([FromQuery] ProductsQuery searchFilter)
        {
            var result = await _mediator.Send(searchFilter);

            //no result is accepted result
            return Ok(result);
        }
     
    }
}
