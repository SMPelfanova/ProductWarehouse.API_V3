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

    public Basket AddBasketLine(Guid userId, BasketLine basketLine)
    {
        var basket = _dbContext.Basket.FirstOrDefault(x => x.UserId == userId);
        if (basket != null)
        {
            basket.BasketLines.Add(basketLine);
        }

        return basket;
    }

    public void DeleteBasketLine(Guid userId, Guid productId)
    {
        var basket = _dbContext.Basket
                              .Include(b => b.BasketLines)
                              .FirstOrDefault(x => x.UserId == userId && x.BasketLines.Any(bl => bl.ProductId == productId));
        if (basket != null)
        {
            var basketLine = basket.BasketLines.FirstOrDefault(bl => bl.ProductId == productId);

            if (basketLine != null)
            {
                _dbContext.BasketLine.Remove(basketLine);
                _dbContext.SaveChanges();
            }
        }
    }

    public void UpdateBasketLine(Guid userId, BasketLine basketLine)
    {
        var basket = _dbContext.Basket
                          .Include(b => b.BasketLines)
                          .FirstOrDefault(x => x.UserId == userId);

        if (basket != null)
        {
            var existingBasketLine = basket.BasketLines.FirstOrDefault(bl => bl.ProductId == basketLine.ProductId);
            if (existingBasketLine != null)
            {
                existingBasketLine.Quantity = basketLine.Quantity;
                existingBasketLine.SizeId = basketLine.SizeId;
            }
        }
    }

    public void DeleteBasket(Guid userId)
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
