using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
}
