using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;

public class AddBasketLineCommandValidator : AbstractValidator<AddBasketLineCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public AddBasketLineCommandValidator(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.UserId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.UserId)));

		RuleFor(command => command.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.ProductId)));

		RuleFor(command => command.Quantity)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.Quantity)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(AddBasketLineCommand.Quantity)))
			.MustAsync(HaveSufficientQuantity)
			.WithMessage("Requested quantity exceeds available quantity.");

		RuleFor(command => command.Price)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.Price)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(AddBasketLineCommand.Price)));
		
		RuleFor(command => command.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.SizeId)))
			.MustAsync((command, sizeId, cancellationToken) => NotAlreadyAdded(command.UserId, command.ProductId, command.SizeId, cancellationToken))
			.WithMessage("Product with the same size is already added to the basket.");
	}

	private async Task<bool> HaveSufficientQuantity(AddBasketLineCommand command, int quantity, CancellationToken cancellationToken)
	{
		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(command.ProductId, command.SizeId);
		return availableSizes >= quantity;
	}

	private async Task<bool> NotAlreadyAdded(Guid userId, Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		bool alreadyAded = await _unitOfWork.BasketLines.CheckProductAndSizeAddedAsync(userId, productId, sizeId);
		
		return !alreadyAded;
	}

}