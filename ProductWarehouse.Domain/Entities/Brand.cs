namespace ProductWarehouse.Domain.Entities;
public class Brand
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
