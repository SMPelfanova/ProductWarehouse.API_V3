using Microsoft.EntityFrameworkCore;
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
        var basket = _dbContext.Basket.Include(b => b.BasketLines).FirstOrDefault(b => b.UserId == userId);

        return basket;
    }

    public void DeleteBasketLines(Guid userId)
    {
        var basket = _dbContext.Basket
                          .Include(b => b.BasketLines)
                          .FirstOrDefault(x => x.UserId == userId);

        if (basket != null)
        {
            _dbContext.BasketLine.RemoveRange(basket.BasketLines);
        }
    }
}
