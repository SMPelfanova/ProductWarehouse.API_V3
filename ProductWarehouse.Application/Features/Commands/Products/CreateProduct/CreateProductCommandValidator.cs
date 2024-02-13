using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(command => command.Title)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateProductCommand.Title)));

		RuleFor(command => command.Title)
			.MaximumLength(100)
			.WithMessage(string.Format(MessageConstants.MaxLengthValidationMessage, nameof(CreateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateProductCommand.Description)));

		RuleFor(command => command.BrandId)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateProductCommand.BrandId)));

		RuleFor(command => command.Price)
			.NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(CreateProductCommand.Price)))
			.GreaterThan(0).WithMessage(string.Format(MessageConstants.GraterThanZeroValidationMessage, nameof(CreateProductCommand.Price)));
	}
}