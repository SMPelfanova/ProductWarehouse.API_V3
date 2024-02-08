namespace ProductWarehouse.Domain.Entities;
public class Brand : Entity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
