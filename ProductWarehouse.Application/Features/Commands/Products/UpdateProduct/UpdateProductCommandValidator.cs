using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
		RuleFor(command => command.Id)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductCommand.Id)));

		RuleFor(command => command.Title)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductCommand.Title)));

		RuleFor(command => command.Title)
			.MaximumLength(100)
			.WithMessage(MessageConstants.MaxLengthValidationMessage(nameof(UpdateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductCommand.Description)));

		RuleFor(command => command.Price)
			.NotEmpty().WithMessage(MessageConstants.RequiredValidationMessage(nameof(UpdateProductCommand.Price)))
			.GreaterThan(0).WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(UpdateProductCommand.Price)));
	}
}