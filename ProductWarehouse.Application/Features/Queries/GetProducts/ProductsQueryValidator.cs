using FluentValidation;

namespace ProductWarehouse.Application.Features.Queries.GetProducts;

public class ProductsQueryValidator: AbstractValidator<ProductsQuery>
{
    public ProductsQueryValidator()
    {
        RuleFor(r => r.MinPrice).GreaterThanOrEqualTo(0).WithMessage("MinPrice must be a non-negative value.");
        RuleFor(r => r.MaxPrice).GreaterThanOrEqualTo(0).WithMessage("MaxPrice must be a non-negative value.");
        RuleFor(r => r.Size).MaximumLength(255).WithMessage("Size parameter cannot exceed 255 characters.");
        RuleFor(r => r.Highlight).MaximumLength(255).WithMessage("Highlight parameter cannot exceed 255 characters.");
    }
}
