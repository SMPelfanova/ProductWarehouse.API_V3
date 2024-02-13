using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Configuration;
using Serilog;

namespace ProductWarehouse.Infrastructure.Http;

public class MockyClientService
{
	private readonly HttpClient _httpClient;
	private readonly ILogger _logger;

	private readonly Uri _productUri;

	public MockyClientService(HttpClient httpClient, ILogger logger, IOptions<MockyClientOptions> config)
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
			_logger.Information($"Response from mocky.io: {jsonString}");
			try
			{
				var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
				_logger.Information($"Returning deserialized product list");
				return products ?? new List<Product>();
			}
			catch (Exception ex)
			{
				_logger.Error(ex, $"Deserialization of product failed: {ex.Message}");
				return new List<Product>();
			}
		}
		else
		{
			_logger.Information($"No products found with status code: {jsonString}");
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