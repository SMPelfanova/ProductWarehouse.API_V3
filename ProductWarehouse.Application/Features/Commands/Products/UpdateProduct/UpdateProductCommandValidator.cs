using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Features.Queries.GetProducts;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
	public UpdateProductCommandValidator()
	{
		RuleFor(command => command.Id)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateProductCommand.Id)));

		RuleFor(command => command.Title)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateProductCommand.Title)));

		RuleFor(command => command.Title)
			.MaximumLength(100)
			.WithMessage(string.Format(MessageConstants.MaxLengthValidationMessage, nameof(UpdateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateProductCommand.Description)));

		RuleFor(command => command.Price)
			.NotEmpty().WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(UpdateProductCommand.Price)))
			.GreaterThan(0).WithMessage(string.Format(MessageConstants.GraterThanZeroValidationMessage, nameof(UpdateProductCommand.Price)));
	}
}