using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
{
	public ProductSizeRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, ILogger logger) : base(dbContext, dbConnection, logger)
	{
	}
}