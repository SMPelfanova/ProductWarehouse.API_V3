namespace ProductWarehouse.Domain.Entities;
public class Order
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public Guid StatusId { get; set; }
    public User User { get; set; }
    public Guid Userid { get; set; }
    public Payment Payment { get; set; }
    public Guid PaymentId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }
}
