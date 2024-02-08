namespace ProductWarehouse.Domain.Entities;
public class Order : Entity
{
    public OrderStatus Status { get; set; }
    public Guid StatusId { get; set; }
    public User User { get; set; }
    public Guid? UserId { get; set; }
    public Payment Payment { get; set; }
    public Guid? PaymentId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; }
    public bool IsDeleted { get; set; }
}
