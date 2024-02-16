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
		//.Must(HaveBasket)
		//.WithMessage(command => $"No basket found for user: {command.UserId}");

		RuleFor(command => command.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.ProductId)));
			//.MustAsync(ExistInProducts)
			//.WithMessage(command => $"Product with Id: {command.ProductId} does not exist.");

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

	//private bool HaveBasket(Guid userId)
	//{
	//	var basket = _unitOfWork.Basket.GetBasketByUserId(userId);
	//	return basket != null;
	//}

	//private async Task<bool> ExistInProducts(Guid productId, CancellationToken cancellationToken)
	//{
	//	var product = await _unitOfWork.Products.GetByIdAsync(productId);
	//	return product != null;
	//}

	private async Task<bool> HaveSufficientQuantity(AddBasketLineCommand command, int quantity, CancellationToken cancellationToken)
	{
		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(command.ProductId, command.SizeId);
		return availableSizes >= quantity;
	}

	private async Task<bool> NotAlreadyAdded(Guid userId, Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		return await _unitOfWork.BasketLines.GetByProductAndSizeAsync(userId, productId, sizeId);
	}

}