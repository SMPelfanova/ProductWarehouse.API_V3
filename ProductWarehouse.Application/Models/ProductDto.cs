using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Models;

public class ProductDto
{
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public string Brand { get; set; }
    //public required List<SizeDto> Sizes { get; set; }
    public required string Description { get; set; }
    public List<string> Sizes { get; set; }
    public List<GroupDto> Groups { get; set; }
}
