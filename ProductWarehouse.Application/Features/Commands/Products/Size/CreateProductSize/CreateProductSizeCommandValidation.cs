using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.Size.CreateProductSize;
public class CreateProductSizeCommandValidation : AbstractValidator<CreateProductSizeCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductSizeCommandValidation(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductSizeCommand.SizeId)))
			.MustAsync((command, sizeId, cancellationToken) => ProductSizeExists(command.ProductId, sizeId, cancellationToken))
			.WithMessage(MessageConstants.AlreadyExistMessage(nameof(CreateProductSizeCommand.SizeId)));
	}

	private async Task<bool> ProductSizeExists(Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(productId);

		if (product != null)
		{
			return !product.ProductSizes.Any(x => x.SizeId == sizeId);
		}

		return product is null;
	}
}