using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.Size.UpdateProductSize;
public class UpdateProductSizeCommandValidator : AbstractValidator<UpdateProductSizeCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductSizeCommandValidator(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductSizeCommand.ProductId)));

		RuleFor(command => command.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductSizeCommand.SizeId)));

		RuleFor(command => command.QuantityInStock)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductSizeCommand.QuantityInStock)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateProductSizeCommand.QuantityInStock)))
			.MustAsync(HaveSufficientQuantity)
			.WithMessage(MessageConstants.NotAvailableQuantityMessage);
	}

	private async Task<bool> HaveSufficientQuantity(UpdateProductSizeCommand command, int quantity, CancellationToken cancellationToken)
	{
		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(command.ProductId, command.SizeId);
		return availableSizes >= quantity;
	}
}
