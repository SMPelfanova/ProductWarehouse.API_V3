using Microsoft.Extensions.Logging;
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

        public async Task<IEnumerable<Product>> GetProductsAsync(decimal? minPrice, decimal? maxPrice, string? size, string? highlight)
        {
            var products = await _dbContext.Products();
            //filter the products
            //if (minPrice )
            //{

            //}

            return products;
        }

    }
}
