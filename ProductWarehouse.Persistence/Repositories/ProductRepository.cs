using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Infrastructure.Http;

namespace ProductWarehouse.Persistence.Repositories;

public class ProductRepository : IProductRepository, IRepository<Product>
{
    private readonly IApplicationDbContext _dbContext;

    public ProductRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Product entity)
    {
        _dbContext.Products.Add(entity);
    }

    public Task<Product> DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var products = _dbContext.Products;
    
        return products.ToList();
    }

    public Task<Product> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }
}