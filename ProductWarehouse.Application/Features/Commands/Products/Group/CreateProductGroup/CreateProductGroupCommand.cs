using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductGroupCommand() : IRequest<ProductGroupDto>
{
	public Guid ProductId { get; set; }
	public Guid GroupId { get; set; }
}