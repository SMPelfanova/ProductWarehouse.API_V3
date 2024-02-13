namespace ProductWarehouse.Domain.Entities;
public class Size : Entity
{
	public string Name { get; set; }
	public ICollection<OrderLine> OrderLines { get; set; }
	public ICollection<BasketLine> BasketLines { get; set; }
	public ICollection<ProductSize> ProductSizes { get; set; }
}
