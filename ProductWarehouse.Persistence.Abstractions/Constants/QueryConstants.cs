namespace ProductWarehouse.Persistence.Abstractions.Constants;
public static class QueryConstants
{
	public static string SelectEntity(string entity) => $"""SELECT * FROM "{entity}" """;
	public static string SelectEntityById(string entity) => $"""SELECT * FROM "{entity}"  WHERE "Id" = @id """;
}