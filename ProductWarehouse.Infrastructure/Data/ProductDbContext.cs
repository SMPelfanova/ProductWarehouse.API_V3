using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Repositories;

namespace ProductWarehouse.Infrastructure.Data
{
    public class ProductDbContext
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductRepository> _logger;
        private const string ProductListURL = "https://run.mocky.io/v3/97aa328f-6f5d-458a-9fa4-55fe58eaacc9";

        public ProductDbContext(HttpClient httpClient, ILogger<ProductRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Product>> Products()
        {
            var response = await _httpClient.GetAsync(ProductListURL);
            _logger.LogInformation($"Response from mocky.io: {response}");
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
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
