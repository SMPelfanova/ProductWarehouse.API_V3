using FluentValidation;
using ProductWarehouse.Application.Constants;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(r => r.MinPrice).GreaterThanOrEqualTo(0).WithMessage(MessageConstants.MinPriceValidationMessage);
        RuleFor(r => r.MaxPrice).GreaterThanOrEqualTo(0).WithMessage(MessageConstants.MaxPriceValidationMessage);
        RuleFor(r => r.Size).MaximumLength(255).WithMessage(MessageConstants.SizeValidationMessage);
        RuleFor(r => r.Highlight).MaximumLength(255).WithMessage(MessageConstants.HihglightValidationMessage);
    }
}
