namespace ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
public static class CommandConstants
{
    public static string InsertProduct = @"
            INSERT INTO ""Products"" (""BrandId"", ""Title"", ""Photo"", ""Price"", ""Description"", ""IsDeleted"") 
            VALUES (@BrandId, @Title, @Photo, @Price, @Description, @IsDeleted)
            RETURNING ""Id"";";

    public static string InsertProductGroup = @"
            INSERT INTO ""ProductGroups"" (""ProductId"", ""GroupId"")
            VALUES (@ProductId, @GroupId);";

	public static string InsertProductSize = @"
            INSERT INTO ""ProductSizes"" (""ProductId"", ""SizeId"", ""QuantityInStock"")
            VALUES (@ProductId, @SizeId, @QuantityInStock);";

    public static string UpdateProduct = @"
            UPDATE ""Products"" 
            SET 
                ""BrandId"" = @BrandId,
                ""Title"" = @Title,
                ""Photo"" = @Photo,
                ""Price"" = @Price,
                ""Description"" = @Description,
                ""IsDeleted"" = @IsDeleted
            WHERE 
                ""Id"" = @Id;";

    public static string UpdateProductIsDeleted = @"
            UPDATE ""Products"" 
            SET 
                ""IsDeleted"" = @IsDeleted
            WHERE 
                ""Id"" = @Id;";

	public static string UpdateQuantityInStock = @"
            UPDATE ""ProductSizes""
            SET ""QuantityInStock"" = @QuantityInStock
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";
	
	public static string DeleteProductGroups = @"
            DELETE FROM ""ProductGroups"" 
            WHERE ""ProductId"" = @ProductId;";

	public static string DeleteProductGroup = @"
            DELETE FROM ""ProductGroups""
            WHERE ""ProductId"" = @ProductId AND ""GroupId"" = @GroupId";

	public static string DeleteProductSizes = @"
            DELETE FROM ""ProductSizes"" 
            WHERE ""ProductId"" = @ProductId;";

	public static string DeleteProductSize = @"
            DELETE FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

	public static string UpdateProductOld = @"
            BEGIN;
            UPDATE ""Products"" 
            SET 
                ""BrandId"" = @BrandId,
                ""Title"" = @Title,
                ""Photo"" = @Photo,
                ""Price"" = @Price,
                ""Description"" = @Description,
                ""IsDeleted"" = @IsDeleted
            WHERE 
                ""Id"" = @Id;

            DELETE FROM ""ProductGroups""
            WHERE ""ProductId"" = @ProductId;

            DELETE FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId;

            INSERT INTO ""ProductGroups"" (""ProductId"", ""GroupId"")
            VALUES (@ProductId, @GroupId)
            ON CONFLICT DO NOTHING;

            INSERT INTO ""ProductSizes"" (""ProductId"", ""SizeId"", ""QuantityInStock"")
            VALUES (@ProductId, @SizeId, @QuantityInStock)
            ON CONFLICT DO NOTHING;";

}