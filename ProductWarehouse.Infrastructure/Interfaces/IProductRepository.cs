using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Infrastructure.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size);
}
