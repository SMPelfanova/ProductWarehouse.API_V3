using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class SizeRepository : Repository<Size>, ISizeRepository
{
	public SizeRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}