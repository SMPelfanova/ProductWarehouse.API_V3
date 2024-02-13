using FluentValidation;
using ProductWarehouse.Application.Features.Queries.GetProduct;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
	public GetProductQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");
	}
}