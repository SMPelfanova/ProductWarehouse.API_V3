using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;
public class BasketLineRepository : Repository<BasketLine>, IBasketLineRepository
{
    public BasketLineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
