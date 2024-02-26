using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.PostgreSQL.Constants;
public static class MessageConstants
{
	public static string NotFoundErrorMessage(string paramName, Guid id) => $"{paramName} with specified id: {id} not found.";
	public static string NotFoundErrorMessage(string paramName) => $"{paramName} not found.";
	public static string GeneralErrorMessage(string paramName) => $"An error occurred while fetching the {paramName}.";
	public static string ProductGroupNotFoundErrorMessage(Guid id, Guid groupId) => $"ProductGroup not found for the specified productId: {id} and groupId: {groupId}.";
	public static string ProductSizeNotFoundErrorMessage(Guid id, Guid sizeId) => $"ProductSize not found for the specified productId: {id} and sizeId: {sizeId}.";
	
}
