using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;

public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
{
	public GetAllOrdersQueryValidator()
	{
		RuleFor(query => query.UserId)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(GetAllOrdersQuery.UserId)));
	}
}