using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = _dbContext.Products;
    
        return products.ToList();
    }
}