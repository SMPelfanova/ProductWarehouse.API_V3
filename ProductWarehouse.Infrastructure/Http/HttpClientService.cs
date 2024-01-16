using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Repositories;

namespace ProductWarehouse.Infrastructure.Http
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductRepository> _logger;

        public HttpClientService(HttpClient httpClient, ILogger<ProductRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Product>> GetProductListAsync(Uri productUri)
        {
            var jsonString = await GetStringAsync(productUri);
            if (!string.IsNullOrEmpty(jsonString))
            {
                _logger.LogInformation($"Response from mocky.io: {jsonString}");
                try
                {
                    var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                    _logger.LogInformation($"Returning deserialized product list");
                    return products ?? new List<Product>();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Deserialization of product failed: {ex.Message}");
                    return new List<Product>();
                }
            }
            else
            {
                _logger.LogWarning($"No products found with status code: {jsonString}");
                return new List<Product>();
            }
        }

        public async Task<string> GetStringAsync(Uri requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri.ToString());

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

    }
}
