using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.StatusId).NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateOrderCommand.StatusId)));
        RuleFor(c => c.TotalAmount).GreaterThan(0).WithMessage(string.Format(MessageConstants.GraterThanZeroValidationMessage, nameof(CreateOrderCommand.TotalAmount)));
        RuleFor(c => c.OrderDate).NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateOrderCommand.OrderDate)));
        RuleFor(c => c.OrderDetails).NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateOrderCommand.OrderDetails)));
    }
}