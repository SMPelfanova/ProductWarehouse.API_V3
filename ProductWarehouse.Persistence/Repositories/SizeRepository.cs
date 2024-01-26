using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class SizeRepository : Repository<Size>, ISizeRepository
{
    public SizeRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}