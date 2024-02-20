using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
	public BrandRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
	}
}