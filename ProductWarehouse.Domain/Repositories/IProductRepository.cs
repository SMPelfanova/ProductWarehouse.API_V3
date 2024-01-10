using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size);
    }
}
