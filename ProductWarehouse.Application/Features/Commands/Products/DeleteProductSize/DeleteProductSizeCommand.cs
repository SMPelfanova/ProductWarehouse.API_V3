using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
public record DeleteProductSizeCommand(Guid ProductId, Guid SizeId) : IRequest;

