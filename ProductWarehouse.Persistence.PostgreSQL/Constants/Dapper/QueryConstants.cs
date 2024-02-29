namespace ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
public static class QueryConstants
{
	public static string GetAllOrderStatusesQuery = "SELECT * FROM \"OrderStatus\"";

	public static string GetOrderStatusByIdQuery = "SELECT * FROM \"OrderStatus\" WHERE \"Id\" = @Id;";

	public static string GetBasketByUserIdQuery = @"
            SELECT 
                b.*, 
                bl.* 
            FROM 
                ""Baskets"" b
            LEFT JOIN 
                ""BasketLines"" bl ON b.""Id"" = bl.""BasketId""
            WHERE 
                b.""UserId"" = @UserId";

	public static string GetOrderDetailsQuery = @"
            SELECT 
                o.*, 
                ol.*,
                os.*
            FROM 
                ""Orders"" o
            LEFT JOIN 
                ""OrderLines"" ol ON o.""Id"" = ol.""OrderId""
            LEFT JOIN
                ""OrderStatus"" os ON o.""StatusId"" = os.""Id""
            WHERE 
                o.""Id"" = @Id 
                AND NOT o.""IsDeleted""";

	public static string GetOrdersByUserIdQuery = @"
            SELECT 
                o.*, 
                ol.*,
                os.*
            FROM 
                ""Orders"" o
            LEFT JOIN 
                ""OrderLines"" ol ON o.""Id"" = ol.""OrderId""
            LEFT JOIN
                ""OrderStatus"" os ON o.""StatusId"" = os.""Id""
            WHERE 
                o.""UserId"" = @UserId 
                AND NOT o.""IsDeleted""";

	public static string GetAllProductsQuery = @"
            SELECT 
                p.*, b.*, pg.*, ps.*, s.*, g.*
            FROM ""Products"" p
            LEFT JOIN ""Brands"" b ON p.""BrandId"" = b.""Id""
            LEFT JOIN ""ProductGroups"" pg ON p.""Id"" = pg.""ProductId""
            LEFT JOIN ""ProductSizes"" ps ON p.""Id"" = ps.""ProductId""
            LEFT JOIN ""Sizes"" s ON ps.""SizeId"" = s.""Id""
            LEFT JOIN ""Groups"" g ON pg.""GroupId"" = g.""Id""
            WHERE p.""IsDeleted"" = FALSE";

	public static string GetProductDetailsQuery = @"
            SELECT 
                p.*, b.*, pg.*, g.*, ps.*, s.*
            FROM 
                ""Products"" p
            LEFT JOIN 
                ""Brands"" b ON p.""BrandId"" = b.""Id""
            LEFT JOIN 
                ""ProductGroups"" pg ON p.""Id"" = pg.""ProductId""
            LEFT JOIN 
                ""Groups"" g ON pg.""GroupId"" = g.""Id""
            LEFT JOIN 
                ""ProductSizes"" ps ON p.""Id"" = ps.""ProductId""
            LEFT JOIN 
                ""Sizes"" s ON ps.""SizeId"" = s.""Id""
            WHERE 
                p.""Id"" = @Id AND p.""IsDeleted"" = FALSE";

	public static string CheckQuantityInStockQuery = @"
            SELECT ""QuantityInStock""
            FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

	public static string GetProductSizeQuery = @"
            SELECT *
            FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

	public static string GetProductGroups = @"
            SELECT 
                pg.*,
                g.*
            FROM 
                ""ProductGroups"" pg
            INNER JOIN 
                ""Groups"" g ON pg.""GroupId"" = g.""Id""
            WHERE 
                pg.""ProductId"" = @ProductId;";

	public static string GetProductSizes = @"
            SELECT 
                ps.*,
                s.*
            FROM 
                ""ProductSizes"" ps
            INNER JOIN 
                ""Sizes"" s ON ps.""SizeId"" = s.""Id""
            WHERE 
                ps.""ProductId"" = @ProductId;";
}