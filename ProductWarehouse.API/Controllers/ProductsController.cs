using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Queries;

namespace ProductWarehouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;
        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult> GetProducts()
        {
            var result = await _mediator.Send(new ProductsQuery());
            if (result == null || !result.Products.Any())
            {
                return NotFound();
            }

            return Ok(result.Products);
        }

        [HttpGet("filter")]
        public async Task<ActionResult> GetProducts([FromQuery] ProductsQuery searchFilter)
        {
            var result = await _mediator.Send(searchFilter);

            //no result is accepted result
            return Ok(result);
        }
     
    }
}
