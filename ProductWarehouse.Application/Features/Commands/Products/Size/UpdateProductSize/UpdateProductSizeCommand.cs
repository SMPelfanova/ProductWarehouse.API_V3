using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
public record UpdateProductSizeCommand(Guid Id, Guid sizeId, int QuantityInStock) : IRequest;