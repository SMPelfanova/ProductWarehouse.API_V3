using FluentValidation;
using ProductWarehouse.Application.Constants;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	private readonly IUnitOfWork _unitOfWork;
	public CreateProductCommandValidator(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;

		RuleFor(command => command.Title)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Title)))
			.MaximumLength(100)
			.WithMessage(MessageConstants.MaxLengthValidationMessage(nameof(CreateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Description)));

		RuleFor(command => command.BrandId)
			  .NotEmpty()
			  .WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.BrandId)))
			  .MustAsync(BrandExists)
			  .WithMessage(MessageConstants.DoesNotExistMessage(nameof(CreateProductCommand.BrandId)));

		RuleForEach(command => command.Sizes)
			.MustAsync(async (sizeId, cancellation) => await SizeExists(sizeId.Id, cancellation))
			.WithMessage(MessageConstants.DoesNotExistMessage(nameof(CreateProductCommand.Sizes)))
			.Must(size => size.QuantityInStock > 0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(CreateProductCommand.Sizes)))
			.When(size => size != null);

		RuleForEach(command => command.Groups)
			.MustAsync(async (groupId, cancellation) => await GroupExists(groupId.Id, cancellation))
			.WithMessage(MessageConstants.DoesNotExistMessage(nameof(CreateProductCommand.Groups)));

		RuleFor(command => command.Price)
			.GreaterThan(0)
			.WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(CreateProductCommand.Price)));
	}

	private async Task<bool> SizeExists(Guid sizeId, CancellationToken cancellationToken)
	{
		var size = await _unitOfWork.Sizes.CheckIfExistsAsync(sizeId);

		return size;
	}

	private async Task<bool> GroupExists(Guid groupId, CancellationToken cancellationToken)
	{
		var group = await _unitOfWork.Group.CheckIfExistsAsync(groupId);

		return group;
	}

	private async Task<bool> BrandExists(Guid brandId, CancellationToken cancellationToken)
	{
		var brand = await _unitOfWork.Brands.CheckIfExistsAsync(brandId);

		return brand;
	}
}