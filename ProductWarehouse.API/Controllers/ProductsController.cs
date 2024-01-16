using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.API.Controllers
{
    /// <summary>
    /// Controller for managing product-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mediator">The mediator.</param>
        public ProductsController(ILogger<ProductsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
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
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
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
        public async Task<ActionResult> GetProducts([FromQuery] FilterProductsRequest productsFilter)
        {
            var productsQueryMap = _mapper.Map<ProductsQuery>(productsFilter);
            var result = await _mediator.Send(productsQueryMap);


            return Ok(result);
        }
     
    }
}
