namespace ProductWarehouse.Persistence.EF.Constants;

public static class DatabaseConstants
{
	public const int One = 1;
	public const int Twenty = 20;
	public const int Thirty = 30;
	public const int Fifty = 50;
	public const int Hundred = 100;
	public const int TwoHundredFiftyFive = 255;

	public const string DecimalColumnType = "decimal(18, 2)";
	public const string DateColumnType = "Date";
	public const string DateDefaultValueSql = "GetDate()";
}