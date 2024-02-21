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

		RuleFor(command => command.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.ProductId)));

		RuleFor(command => command.Quantity)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.Quantity)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateBasketLineCommand.Quantity)))
			.MustAsync(HaveSufficientQuantity)
			.WithMessage(MessageConstants.NotAvailableQuantityMessage);

		RuleFor(command => command.Price)
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateBasketLineCommand.Price)));

		RuleFor(command => command.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateBasketLineCommand.SizeId)));
	}
	
	private async Task<bool> HaveSufficientQuantity(UpdateBasketLineCommand command, int quantity, CancellationToken cancellationToken)
	{
		var availableSizes = await _unitOfWork.Products.CheckQuantityInStockAsync(command.ProductId, command.SizeId);
		return availableSizes >= quantity;
	}
}