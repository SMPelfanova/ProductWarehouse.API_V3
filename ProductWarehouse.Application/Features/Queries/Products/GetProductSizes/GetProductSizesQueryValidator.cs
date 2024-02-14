using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;

public class GetProductSizesQueryValidator : AbstractValidator<GetProductSizesQuery>
{
	public GetProductSizesQueryValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(GetProductSizesQuery.Id)));
	}
}