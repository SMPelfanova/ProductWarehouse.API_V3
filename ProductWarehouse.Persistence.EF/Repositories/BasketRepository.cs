using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;
public class BasketRepository : Repository<Basket>, IBasketRepository
{
    private readonly ApplicationDbContext _dbContext;
    public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Basket GetBasketByUserId(Guid userId)
    {
        return _dbContext.Basket.FirstOrDefault(b => b.UserId == userId);
    }
}
