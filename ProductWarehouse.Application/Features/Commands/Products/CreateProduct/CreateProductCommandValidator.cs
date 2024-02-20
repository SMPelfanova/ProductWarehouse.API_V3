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
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Title)));

		RuleFor(command => command.Title)
			.MaximumLength(100)
			.WithMessage(MessageConstants.MaxLengthValidationMessage(nameof(CreateProductCommand.Title), 100));

		RuleFor(command => command.Description)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Description)));

		RuleFor(command => command.BrandId)
			  .NotEmpty()
			  .WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.BrandId)))
			  .MustAsync(BrandExists)
			  .WithMessage("Brand does not exist.");

		RuleForEach(command => command.Sizes)
			.MustAsync(async (sizeId, cancellation) => await SizeExists(sizeId.Id, cancellation))
			.WithMessage("Size does not exist.");

		RuleForEach(command => command.Groups)
			.MustAsync(async (groupId, cancellation) => await GroupExists(groupId.Id, cancellation))
			.WithMessage("Group does not exist.");

		RuleFor(command => command.Price)
			.NotEmpty().WithMessage(MessageConstants.RequiredValidationMessage(nameof(CreateProductCommand.Price)))
			.GreaterThan(0).WithMessage(MessageConstants.GraterThanZeroValidationMessage(nameof(CreateProductCommand.Price)));
	}

	private async Task<bool> SizeExists(Guid sizeId, CancellationToken cancellationToken)
	{
		var size = await _unitOfWork.Sizes.ExistsAsync(sizeId);

		return size;
	}

	private async Task<bool> GroupExists(Guid groupId, CancellationToken cancellationToken)
	{
		var group = await _unitOfWork.Group.ExistsAsync(groupId);

		return group;
	}

	private async Task<bool> BrandExists(Guid brandId, CancellationToken cancellationToken)
	{
		var brand = await _unitOfWork.Brands.ExistsAsync(brandId);

		return brand;
	}

}