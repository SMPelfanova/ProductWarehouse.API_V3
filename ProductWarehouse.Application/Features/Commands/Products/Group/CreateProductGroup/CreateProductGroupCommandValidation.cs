using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.Group.CreateProductGroup;
public class CreateProductGroupCommandValidation : AbstractValidator<CreateProductGroupCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductGroupCommandValidation(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.GroupId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductGroupCommand.GroupId)))
			.MustAsync((command, sizeId, cancellationToken) => ProductSizeExists(command.ProductId, sizeId, cancellationToken))
			.WithMessage(MessageConstants.AlreadyExistMessage(nameof(CreateProductGroupCommand.GroupId)));
	}

	private async Task<bool> ProductSizeExists(Guid productId, Guid groupId, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(productId, cancellationToken);

		if (product != null)
		{
			return !product.ProductGroups.Any(x => x.GroupId == groupId);
		}
		return product is null;
	}
}