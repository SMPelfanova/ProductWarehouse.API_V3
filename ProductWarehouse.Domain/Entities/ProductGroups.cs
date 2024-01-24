namespace ProductWarehouse.Domain.Entities;
public class ProductGroups
{
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public Group Group { get; set; }
    public Guid GroupId { get; set; }
}
