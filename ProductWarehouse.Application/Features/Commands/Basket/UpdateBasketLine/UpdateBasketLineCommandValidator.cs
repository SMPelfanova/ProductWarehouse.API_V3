using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;

public class UpdateBasketLineCommandValidator : AbstractValidator<UpdateBasketLineCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateBasketLineCommandValidator(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.UserId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.UserId)));

		RuleFor(command => command.Id)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.Id)));
		//.MustAsync(HaveBasketLine)
		//.WithMessage(command => $"No basket line found with id: {command.Id}");

		RuleFor(command => command.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.ProductId)));
			//.MustAsync(ExistInProducts)
			//.WithMessage(command => $"Product with Id: {command.ProductId} does not exist.");

		RuleFor(command => command.Quantity)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.Quantity)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateBasketLineCommand.Quantity)))
			.MustAsync(HaveSufficientQuantity)
			.WithMessage("Requested quantity exceeds available quantity.");

		RuleFor(command => command.Price)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.Price)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateBasketLineCommand.Price)));

		RuleFor(command => command.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.SizeId)));
		
	}
	//private async Task<bool> HaveBasketLine(Guid basketLineId, CancellationToken cancellationToken)
	//{
	//	var basketLine = await _unitOfWork.BasketLines.GetByIdAsync(basketLineId);
	//	return basketLine is not null;
	//}

	//private async Task<bool> ExistInProducts(Guid productId, CancellationToken cancellationToken)
	//{
	//	var product = await _unitOfWork.Products!.GetByIdAsync(productId);
	//	return product is not null;
	//}

	private async Task<bool> HaveSufficientQuantity(UpdateBasketLineCommand command, int quantity, CancellationToken cancellationToken)
	{
		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(command.ProductId, command.SizeId);
		return availableSizes >= quantity;
	}
}