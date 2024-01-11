using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Repositories;

namespace ProductWarehouse.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductRepository> _logger;
        private readonly string _productListURL;

        public ProductRepository(HttpClient httpClient, ILogger<ProductRepository> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _productListURL = config.GetSection("ProductSourceSettings:ProductListURL").Value ?? throw new ArgumentNullException("ProductListURL is missing in configuration");
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size)
        {
            var products = await GetProductListAsync();

            products = products.Where(x => (minPrice == 0 || x.Price >= minPrice))
                .Where(x => (maxPrice == 0 || x.Price <= maxPrice))
                .Where(x => (string.IsNullOrEmpty(size) || x.Sizes.Any(s => s.ToLowerInvariant() == size.ToLowerInvariant()))).ToList();

            return products;
        }

        private async Task<List<Product>> GetProductListAsync()
        {
            var response = await _httpClient.GetAsync(_productListURL);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Response from mocky.io: {jsonString}");

                    var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);

                    _logger.LogInformation($"Returning deserialized product list");

                    return products ?? new List<Product>();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Deserialization of product failed: {ex.Message}");
                    return null;
                }
            }
            else
            {
                _logger.LogWarning($"No products found with status code: {response.StatusCode}");
                return new List<Product>();
            }
        }
    }
}
