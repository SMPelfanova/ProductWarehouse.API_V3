using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
public record DeleteProductGroupCommand() : IRequest
{
	public Guid ProductId { get; set; }
	public Guid GroupId { get; set; }
}