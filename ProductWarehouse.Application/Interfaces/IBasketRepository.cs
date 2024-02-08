using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IBasketRepository : IRepository<Basket>
{
    Basket GetBasketByUserId(Guid userId);
    Guid CreateBasket(Basket basket);
    void DeleteBasket(Basket basket);
    void UpdateBasket(Basket basket);

    Basket AddBasketLine(Guid userId, BasketLine basketLine);
    void DeleteBasketLine(Guid userId, Guid basketId);
    void UpdateBasketLine(Guid userId, Guid basketId, BasketLine basketLine);
}
