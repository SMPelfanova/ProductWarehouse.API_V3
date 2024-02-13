using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
{
	public GetOrderQueryValidator()
	{
		RuleFor(query => query.Id).NotEmpty().WithMessage("Id cannot be empty.");
		RuleFor(query => query.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
	}
}