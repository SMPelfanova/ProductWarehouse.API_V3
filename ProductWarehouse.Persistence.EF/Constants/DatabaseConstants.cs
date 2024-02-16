namespace ProductWarehouse.Persistence.EF.Constants;

public static class DatabaseConstants
{
	public const string OrderLines = "OrderLines";
	public const string OrderStatus = "OrderStatus";
	public const string UserRoles = "UserRoles";
	public const string ProductGroups = "ProductGroups";
	public const string ProductSizes = "ProductSizes";

	public const string DecimalColumnType = "decimal(18, 2)";
	public const string DateColumnType = "Date";
	public const string DateDefaultValueSql = "GetDate()";
}