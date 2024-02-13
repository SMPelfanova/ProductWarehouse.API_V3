using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

public class GetProductGroupsQueryValidator : AbstractValidator<GetProductGroupsQuery>
{
	public GetProductGroupsQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");
	}
}