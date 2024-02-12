using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(r => r.MinPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage(string.Format(MessageConstants.NonNegativeValidationMessage, nameof(GetAllProductsQuery.MinPrice)));

        RuleFor(r => r.MaxPrice)
            .GreaterThanOrEqualTo(0)
			.WithMessage(string.Format(MessageConstants.NonNegativeValidationMessage, nameof(GetAllProductsQuery.MaxPrice)));

		RuleFor(r => r.Size)
            .MaximumLength(255)
			.WithMessage(string.Format(MessageConstants.MaxLengthValidationMessage, nameof(GetAllProductsQuery.Size), 255));

		RuleFor(r => r.Highlight)
            .MaximumLength(255)
			.WithMessage(string.Format(MessageConstants.MaxLengthValidationMessage, nameof(GetAllProductsQuery.Highlight), 255));

	}
}
