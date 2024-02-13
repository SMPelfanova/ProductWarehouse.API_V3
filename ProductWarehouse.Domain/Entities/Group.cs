namespace ProductWarehouse.Domain.Entities;
public class Group : Entity
{
	public string Name { get; set; }
	public ICollection<ProductGroups> ProductGroups { get; set; }
}
