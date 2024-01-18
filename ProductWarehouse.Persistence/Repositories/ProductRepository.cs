using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProductWarehouse.Application.Contracts;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Infrastructure.Http;

namespace ProductWarehouse.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MockyClientService _httpClientService;


    public ProductRepository(MockyClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size)
    {
        var products = await _httpClientService.GetProductListAsync();

        products = products.Where(x => (minPrice == 0 || x.Price >= minPrice))
            .Where(x => (maxPrice == 0 || x.Price <= maxPrice))
            .Where(x => (string.IsNullOrEmpty(size) || x.Sizes.Any(s => s.ToLowerInvariant() == size.ToLowerInvariant()))).ToList();

        return products;
    }
}