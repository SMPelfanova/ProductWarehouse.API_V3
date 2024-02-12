using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.Basket.GetBasket;
public class GetBasketQueryValidator : AbstractValidator<GetBasketQuery>
{
	public GetBasketQueryValidator()
	{
		RuleFor(query => query.UserId).NotEmpty().WithMessage("User Id cannot be empty.");
	}
}
