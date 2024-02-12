using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductSizes;
public class GetProductSizesQueryValidator : AbstractValidator<GetProductSizesQuery>
{
	public GetProductSizesQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");
	}
}
