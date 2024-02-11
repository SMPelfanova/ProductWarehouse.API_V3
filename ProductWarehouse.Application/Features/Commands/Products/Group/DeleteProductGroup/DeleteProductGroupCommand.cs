using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;
public record DeleteProductGroupCommand(Guid ProductId, Guid GroupId) : IRequest;

