using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetAllOrders;
public class GetAllOrdersQueryValidator : AbstractValidator<GetAllOrdersQuery>
{
	public GetAllOrdersQueryValidator()
	{
		RuleFor(query => query.UserId).NotEmpty().WithMessage("User Id cannot be empty.");
	}
}
