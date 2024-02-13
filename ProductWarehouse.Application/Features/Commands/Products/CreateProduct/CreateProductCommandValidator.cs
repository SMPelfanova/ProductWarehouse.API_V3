using FluentValidation;

namespace ProductWarehouse.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(command => command.Title).NotEmpty().WithMessage("Title is required.");
		RuleFor(command => command.Title).MaximumLength(100).WithMessage("Title maximum length is 100.");
		RuleFor(command => command.Description).NotEmpty().WithMessage("Description is required.");
		RuleFor(command => command.BrandId).NotEmpty().WithMessage("Brand ID is required.");
		RuleFor(command => command.Price).NotEmpty().WithMessage("Price is required.")
										   .GreaterThan(0).WithMessage("Price must be greater than 0.");
	}
}