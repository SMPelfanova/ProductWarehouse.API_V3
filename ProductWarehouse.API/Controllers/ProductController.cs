using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.Application.Queries;

namespace ProductWarehouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;
        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("filter")]
        public async Task<ActionResult> GetProducts([FromQuery] GetProductsQuery searchFilter)
        {
            var result = await _mediator.Send(searchFilter);

            return Ok(result);
        }
     
    }
}
