namespace ProductWarehouse.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Brand Brand { get; set; }
    public Guid BrandId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<ProductGroups> ProductGroups { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
    public ICollection<BasketLine> BasketLines { get; set; }
    public ICollection<ProductSize> ProductSizes { get; set; }
    public bool IsDeleted { get; set; }
}
