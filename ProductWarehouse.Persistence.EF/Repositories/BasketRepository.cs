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

    public Basket AddBasketItem(Guid userId, BasketLine basketLine)
    {
        var basket = _dbContext.Basket.FirstOrDefault(x => x.UserId == userId);
        if (basket != null)
        {
            basket.BasketLines.Add(basketLine);
        }

        return basket;
    }

    public Basket AddBasketLine(Guid userId, BasketLine basketLine)
    {
        throw new NotImplementedException();
    }

    public Guid CreateBasket(Basket basket)
    {
         _dbContext.Basket.Add(new Basket { UserId = basket.UserId, BasketLines = basket.BasketLines });
        return basket.UserId;
    }

    public void DeleteBasket(Basket basket)
    {
        throw new NotImplementedException();
    }

    public void DeleteBasketLine(Guid userId, Guid basketId)
    {
        var basket = _dbContext.Basket
                              .Include(b => b.BasketLines)
                              .FirstOrDefault(x => x.UserId == userId && x.BasketLines.Any(bl => bl.BasketId == basketId));
        if (basket != null)
        {
            var basketLine = basket.BasketLines.FirstOrDefault(bl => bl.BasketId == basketId);

            if (basketLine != null)
            {
                _dbContext.BasketLine.Remove(basketLine);
                _dbContext.SaveChanges();
            }
        }
    }

    public Basket GetBasketByUserId(Guid userId)
    {
        var basket = _dbContext.Basket.Include(b => b.BasketLines).FirstOrDefault(b=>b.UserId == userId);
       
        return basket;
    }

    public void UpdateBasket(Basket basket)
    {
        throw new NotImplementedException();
    }

    public void UpdateBasketLine(Guid basketId, BasketLine basketLine)
    {
        throw new NotImplementedException();
    }

    public void UpdateBasketLine(Guid userId, Guid basketId, BasketLine basketLine)
    {
        throw new NotImplementedException();
    }
}
