using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.Basket.GetBasket;

public class GetBasketQueryValidator : AbstractValidator<GetBasketQuery>
{
	public GetBasketQueryValidator()
	{
		RuleFor(query => query.UserId)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(GetBasketQuery.UserId)));
	}
}