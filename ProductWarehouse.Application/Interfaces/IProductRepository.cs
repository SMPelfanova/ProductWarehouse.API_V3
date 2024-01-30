using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository: IRepository<Product>
{
    Task<Product> GetProductDetails(Guid id);
    Task<Product> GetProductBrand(Guid id);
    Task<Product> GetProductGroups(Guid id);
    Task<Product> GetProductSizes(Guid id);
}
