using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

public class GetProductGroupsQueryValidator : AbstractValidator<GetProductGroupsQuery>
{
	public GetProductGroupsQueryValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage(MessageConstants.RequiredValidationMessage(nameof(GetProductGroupsQuery.Id)));
	}
}