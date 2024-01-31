using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Models;

public class ProductDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public string Brand { get; set; }
    public required string Description { get; set; }
    public List<SizeDto> Sizes { get; set; }
    public List<GroupDto> Groups { get; set; }
}
