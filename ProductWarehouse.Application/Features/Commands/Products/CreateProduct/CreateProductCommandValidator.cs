using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(command => command.Title)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Title)));

		RuleFor(command => command.Title)
			.MaximumLength(100)
			.WithMessage(MessageConstants.MaxLengthValidationMessage(nameof(CreateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Description)));

		RuleFor(command => command.BrandId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.BrandId)));

		RuleFor(command => command.Price)
			.NotEmpty().WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Price)))
			.GreaterThan(0).WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(CreateProductCommand.Price)));
	}
}