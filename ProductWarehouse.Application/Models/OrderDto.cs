namespace ProductWarehouse.Application.Models;
public class OrderDto
{
    public Guid Id { get; set; }
    public OrderStatusDto Status { get; set; }
    public Guid StatusId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    public ICollection<OrderLineDto> OrderLines { get; set; }
}
