using FluentValidation;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
public class AddBasketLineCommandValidator : AbstractValidator<AddBasketLineCommand>
{
    public AddBasketLineCommandValidator()
    {
		RuleFor(command => command.UserId).NotEmpty().WithMessage("User Id cannot be empty.");
		RuleFor(command => command.BasketLine).NotNull().WithMessage("Basket line cannot be null.");
	}
}
