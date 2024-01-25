using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository: IRepository<Product>
{
}
