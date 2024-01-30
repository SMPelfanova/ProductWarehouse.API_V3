using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF;
using System.Formats.Asn1;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
{

    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Product> GetProductBrand(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProductDetails(Guid id)
    {
        var product = await _dbContext.Products
            .Where(p => p.Id == id)
            .Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
            .Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
            .FirstOrDefaultAsync();

        return product;
    }

    public Task<Product> GetProductGroups(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductSizes(Guid id)
    {
        throw new NotImplementedException();
    }
}