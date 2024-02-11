using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductGroupCommand(Guid ProductId, Guid GroupId) : IRequest<Guid>;