using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Contracts;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
}
