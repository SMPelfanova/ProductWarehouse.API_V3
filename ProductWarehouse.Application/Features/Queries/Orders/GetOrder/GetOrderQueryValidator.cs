using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
{
	public GetOrderQueryValidator()
	{
		RuleFor(query => query.Id)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(GetOrderQuery.Id)));

		RuleFor(query => query.UserId)
			.NotEmpty()
			.WithMessage(string.Format(MessageConstants.RequiredValidationMessage, nameof(GetOrderQuery.UserId)));
	}
}