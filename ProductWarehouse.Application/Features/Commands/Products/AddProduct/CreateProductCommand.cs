using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductCommand() : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid GroupId { get; set; }
    public Guid SizeId { get; set; }
    public Guid BrandId { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }

}
