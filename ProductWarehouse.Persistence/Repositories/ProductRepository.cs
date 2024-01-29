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

    public async Task<Product> GetProductDetails(Guid id)
    {
        var product = await _dbContext.Products
            .Where(p => p.Id == id)
            .Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
            .Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
            .FirstOrDefaultAsync();

        return product;
    }
}