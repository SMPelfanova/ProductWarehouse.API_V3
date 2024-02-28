namespace ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper.Queries;
public static class QueryConstants
{
	public static string GetAllOrderStatusesQuery => "SELECT * FROM \"OrderStatus\"";
	public static string GetOrderStatusByIdQuery => "SELECT * FROM \"OrderStatus\" WHERE \"Id\" = @Id;";

	public static string SelectBasketByUserId = @"
            SELECT 
                b.*, 
                bl.* 
            FROM 
                ""Baskets"" b
            LEFT JOIN 
                ""BasketLines"" bl ON b.""Id"" = bl.""BasketId""
            WHERE 
                b.""UserId"" = @UserId";
	//$"SELECT * FROM \"Baskets\" WHERE \"UserId\" = @UserId";
}
