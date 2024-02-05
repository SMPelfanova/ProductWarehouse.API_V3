using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IOrderRepository : IRepository<Order>
{
    Task<Order> GetOrderStatus(Guid id);
    Task<Order> GetOrderDetails(Guid id);
}
