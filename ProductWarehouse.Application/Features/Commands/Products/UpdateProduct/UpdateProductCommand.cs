using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
public class UpdateProductCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid BrandId { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public List<SizeDto> Sizes { get; set; }
    public List<GroupDto> Groups { get; set; }
}
