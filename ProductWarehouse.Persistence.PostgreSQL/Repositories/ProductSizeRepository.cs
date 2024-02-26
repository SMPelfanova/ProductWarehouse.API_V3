using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
{
	public ProductSizeRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
	}
}