namespace ProductWarehouse.Application.Constants;

public static class MessageConstants
{
    public const string RequiredValidationMessage = "{0} is required.";
    public const string GraterThanZeroValidationMessage = "{0} must begrater than 0.";
    public const string MinPriceValidationMessage = "MinPrice must be a non-negative value.";
    public const string MaxPriceValidationMessage = "MaxPrice must be a non-negative value.";
    public const string SizeValidationMessage = "Size parameter cannot exceed 255 characters.";
    public const string HihglightValidationMessage = "Highlight parameter cannot exceed 255 characters.";
}
