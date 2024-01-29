using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProduct;
public record DeleteProductCommand(Guid Id) : IRequest;

