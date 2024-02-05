using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductSizeCommand(Guid ProductId, Guid SizeId) : IRequest<Guid>;
