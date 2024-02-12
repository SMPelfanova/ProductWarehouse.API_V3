using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
public class UpdateBasketLineCommandValidator : AbstractValidator<UpdateBasketLineCommand>
{
    public UpdateBasketLineCommandValidator()
    {
		RuleFor(command => command.UserId)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateBasketLineCommand.UserId)));

		RuleFor(command => command.BasketLine)
			.NotNull()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateBasketLineCommand.BasketLine)));

		//todo: BasketLineDto.
		RuleFor(command => command.BasketLine.Id)
			.NotEmpty()
			.WithMessage("BasketLine Id is required.");

		RuleFor(command => command.BasketLine.BasketId)
			.NotEmpty()
			.WithMessage("BasketLine BasketId is required.");

		RuleFor(command => command.BasketLine.ProductId).NotEmpty().WithMessage("BasketLine ProductId is required.");
		RuleFor(command => command.BasketLine.Quantity).NotEmpty().WithMessage("BasketLine Quantity is required.")
														.GreaterThan(0).WithMessage("BasketLine Quantity must be greater than 0.");
		RuleFor(command => command.BasketLine.Price).NotEmpty().WithMessage("BasketLine Price is required.")
													 .GreaterThan(0).WithMessage("BasketLine Price must be greater than 0.");
		RuleFor(command => command.BasketLine.SizeId).NotEmpty().WithMessage("BasketLine SizeId is required.");
	}
}
