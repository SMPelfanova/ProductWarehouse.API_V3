using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;

public class AddBasketLineCommandValidator : AbstractValidator<AddBasketLineCommand>
{
	public AddBasketLineCommandValidator()
	{
		RuleFor(command => command.UserId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.UserId)));

		RuleFor(command => command.BasketLine)
			.NotNull()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.BasketLine)));

		RuleFor(command => command.BasketLine.ProductId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.BasketLine.ProductId)));

		RuleFor(command => command.BasketLine.Quantity)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.BasketLine.Quantity)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(AddBasketLineCommand.BasketLine.Quantity)));

		RuleFor(command => command.BasketLine.Price)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.BasketLine.Price)))
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(AddBasketLineCommand.BasketLine.Price)));
		
		RuleFor(command => command.BasketLine.SizeId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(AddBasketLineCommand.BasketLine.SizeId)));
	}
}