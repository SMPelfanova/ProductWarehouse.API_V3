using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
	public CreateOrderCommandValidator()
	{
		RuleFor(query => query.UserId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateOrderCommand.UserId)));

		RuleFor(c => c.TotalAmount)
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(CreateOrderCommand.TotalAmount)));

		RuleFor(c => c.OrderLines)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateOrderCommand.OrderLines)));
	}
}