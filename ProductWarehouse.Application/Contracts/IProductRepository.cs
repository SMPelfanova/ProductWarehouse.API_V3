using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Contracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size);
}
