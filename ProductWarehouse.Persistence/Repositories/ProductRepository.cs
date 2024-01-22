using ProductWarehouse.Application.Contracts;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Http;

namespace ProductWarehouse.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MockyClientService _httpClientService;

    public ProductRepository(MockyClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = await _httpClientService.GetProductListAsync();
    
        return products;
    }
}