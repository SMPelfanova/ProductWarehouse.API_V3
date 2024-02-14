namespace ProductWarehouse.Application.Constants;

public static class MessageConstants
{
	public static string RequiredValidationMessage(string paramName) => $"{paramName} is required.";
	public static string GraterThanZeroValidationMessage(string paramName) => $"{paramName} must be greater than 0.";
	public static string NonNegativeValidationMessage(string paramName) => $"{paramName} must be a non-negative value.";
	public static string MaxLengthValidationMessage(string paramName, int maxLength) => $"{paramName} cannot exceed {maxLength} characters.";
}