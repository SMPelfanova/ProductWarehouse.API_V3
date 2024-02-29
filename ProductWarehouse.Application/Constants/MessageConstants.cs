namespace ProductWarehouse.Application.Constants;

public static class MessageConstants
{
	public static string RequiredValidationMessage(string paramName) => $"{paramName} is required.";
	public static string GraterThanZeroValidationMessage(string paramName) => $"{paramName} must be greater than 0.";
	public static string NonNegativeValidationMessage(string paramName) => $"{paramName} must be a non-negative value.";
	public static string MaxLengthValidationMessage(string paramName, int maxLength) => $"{paramName} cannot exceed {maxLength} characters.";
	
	public static string DoesNotExistMessage(string paramName) => $"{paramName} does not exist.";
	public static string AlreadyExistMessage(string paramName) => $"{paramName} already exist.";

	public const string NotAvailableQuantityMessage = "Requested quantity exceeds available quantity.";
	public const string ProductSizeAlreadyAddedMessage = "Product with the same size is already added to the basket.";
	public const string GeneralErrorMessage = "An error occurred while processing the request.";
}