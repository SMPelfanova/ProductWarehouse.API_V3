using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductGroup;

public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteProductGroupCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.Products.DeleteProductGroup(request.ProductId, request.GroupId);
		await _unitOfWork.SaveChangesAsync();
	}
}