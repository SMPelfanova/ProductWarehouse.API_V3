using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models;

namespace ProductWarehouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<ProductDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ProductDto
            {
               
            })
            .ToArray();
        }
    }
}
