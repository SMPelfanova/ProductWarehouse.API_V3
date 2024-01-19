using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Application.Logging;

namespace ProductWarehouse.Infrastructure.Http;

public class MockyClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MockyClientService> _logger;

    private readonly Uri _productUri;

    public MockyClientService(HttpClient httpClient, ILogger<MockyClientService> logger, IOptions<MockyClientOptions> config)
    {
        _httpClient = httpClient;
        _logger = logger;

        Uri baseUri = new Uri(config.Value.BaseUrl);
        _productUri = new Uri(baseUri, config.Value.ProductUrl);
    }

    public virtual async Task<List<Product>> GetProductListAsync()
    {
        var jsonString = await GetStringAsync(_productUri);
        if (!string.IsNullOrEmpty(jsonString))
        {
            LoggingMessageDefinitions.LogInformationMessage(_logger, $"Response from mocky.io: {jsonString}");
            try
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                LoggingMessageDefinitions.LogInformationMessage(_logger, $"Returning deserialized product list");
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
            LoggingMessageDefinitions.LogInformationMessage(_logger, $"No products found with status code: {jsonString}");
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
