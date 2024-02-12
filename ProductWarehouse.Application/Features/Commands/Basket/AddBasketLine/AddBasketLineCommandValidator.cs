using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
public class AddBasketLineCommandValidator : AbstractValidator<AddBasketLineCommand>
{
    public AddBasketLineCommandValidator()
    {
		RuleFor(command => command.UserId)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(AddBasketLineCommand.UserId)));
	
		RuleFor(command => command.BasketLine)
			.NotNull().WithMessage("Basket line cannot be null.");

		RuleFor(command => command.BasketLine.ProductId)
			.NotEmpty()
			.WithMessage("BasketLine ProductId is required.");

		RuleFor(command => command.BasketLine.Quantity)
			.NotEmpty().WithMessage("BasketLine Quantity is required.")
			.GreaterThan(0).WithMessage("BasketLine Quantity must be greater than 0.");

		RuleFor(command => command.BasketLine.Price)
			.NotEmpty().WithMessage("BasketLine Price is required.")
			.GreaterThan(0).WithMessage("BasketLine Price must be greater than 0.");

		RuleFor(command => command.BasketLine.SizeId)
			.NotEmpty().WithMessage("BasketLine SizeId is required.");
	}
}