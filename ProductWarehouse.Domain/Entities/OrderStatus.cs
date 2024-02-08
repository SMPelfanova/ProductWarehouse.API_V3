namespace ProductWarehouse.Domain.Entities;
public class OrderStatus : Entity
{
    public string Name { get; set; }

    public ICollection<Order> Orders { get; set; }
}
