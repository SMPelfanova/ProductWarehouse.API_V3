using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Repositories;
using ProductWarehouse.Infrastructure.Data;

namespace ProductWarehouse.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size)
        {
            var products = await _dbContext.Products();

            products = products.Where(x => (minPrice == 0 || x.Price >= minPrice))
                .Where(x => (maxPrice == 0 || x.Price <= maxPrice))
                .Where(x => (string.IsNullOrEmpty(size) || x.Sizes.Any(s => s.ToLowerInvariant() == size.ToLowerInvariant()))).ToList();

            return products;
        }

    }
}
