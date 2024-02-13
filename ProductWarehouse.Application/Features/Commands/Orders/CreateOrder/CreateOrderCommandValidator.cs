using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateOrderCommandValidator()
	{
		RuleFor(query => query.UserId).NotEmpty().WithMessage("User Id cannot be empty.");
		RuleFor(c => c.TotalAmount).GreaterThan(0).WithMessage(string.Format(MessageConstants.GraterThanZeroValidationMessage, nameof(CreateOrderCommand.TotalAmount)));
		RuleFor(c => c.OrderLines).NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateOrderCommand.OrderLines)));
	}
}