using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IBasketRepository : IRepository<Basket>
{
    Basket GetBasketByUserId(Guid userId);
    Basket AddBasketLine(Guid userId, BasketLine basketLine);
    void DeleteBasketLine(Guid userId, Guid productId);
    void DeleteBasket(Guid userId);
    void UpdateBasketLine(Guid userId, BasketLine basketLine);
}
