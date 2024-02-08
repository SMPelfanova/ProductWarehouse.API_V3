using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> GetProductDetails(Guid id)
    {
        var product = await _dbContext.Products
            .Where(p => p.Id == id)
            .Include(p => p.Brand)
            .Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
            .Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
            .FirstOrDefaultAsync();

        return product;
    }

    public void DeleteProductGroups(Guid productId, Guid groupId)
    {
        var entityToDelete = _dbContext.ProductGroups.FirstOrDefault(x=>x.ProductId == productId && x.GroupId == groupId);
        
        if(entityToDelete != null)
        {
            _dbContext.ProductGroups.Remove(entityToDelete);
            //_dbContext.SaveChanges();
        }
    }

    public void DeleteProductSizes(Guid productId, Guid sizeId)
    {
        var entityToDelete = _dbContext.ProductSizes.FirstOrDefault(x => x.ProductId == productId && x.SizeId == sizeId);

        if (entityToDelete != null)
        {
            _dbContext.ProductSizes.Remove(entityToDelete);
        }
    }

    //public void UpdateProductGroupd(Product product)
    //{
    //    var resutl = _dbContext.ProductGroups.FirstOrDefault(x => x.ProductId == product.Id);

        
    //    if (entityToUpdate != null)
    //    {
    //        entityToUpdate.QuantityInStock = productSize.QuantityInStock;
    //        _dbContext.ProductSizes.Update(entityToUpdate);
    //    }
    //}

    public void UpdateProductSize(ProductSize productSize)
    {
        var entityToUpdate = _dbContext.ProductSizes.FirstOrDefault(x => x.ProductId == productSize.ProductId && x.SizeId == productSize.SizeId);
        if (entityToUpdate != null)
        {
            entityToUpdate.QuantityInStock = productSize.QuantityInStock;
            _dbContext.ProductSizes.Update(entityToUpdate);
        }
    }

    public async Task<ProductSize> GetProductSize(Guid productId, Guid sizeId)
    {
        var productSize = await _dbContext.ProductSizes.FirstOrDefaultAsync(x => x.ProductId == productId && x.SizeId == sizeId);

        return productSize;
    }
}