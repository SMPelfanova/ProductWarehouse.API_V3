using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
{
	public ProductSizeRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}