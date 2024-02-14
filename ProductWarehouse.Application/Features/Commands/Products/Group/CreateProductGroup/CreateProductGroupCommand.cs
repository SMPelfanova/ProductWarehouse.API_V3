using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductGroupCommand() : IRequest<Guid>
{
	public Guid ProductId { get; set; }
	public Guid GroupId { get; set; }
}