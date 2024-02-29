namespace ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
public static class CommandConstants
{
	public static string UpdateQuantityInStock = @"
            UPDATE ""ProductSizes""
            SET ""QuantityInStock"" = @QuantityInStock
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

	public static string DeleteProductSize = @"
            DELETE FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";
	
    public static string DeleteProductGroup= @"
            DELETE FROM ""ProductGroups""
            WHERE ""ProductId"" = @ProductId AND ""GroupId"" = @GroupId";

	public static string UpdatePproduct= @"
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

	public static string DeleteProductGroups = @"
                    DELETE FROM ""ProductGroups"" 
                    WHERE ""ProductId"" = @ProductId;";

	public static string DeleteProductSizes = @"
                    DELETE FROM ""ProductSizes"" 
                    WHERE ""ProductId"" = @ProductId;";

	public static string InsertProductGroup = @"
                        INSERT INTO ""ProductGroups"" (""ProductId"", ""GroupId"")
                        VALUES (@ProductId, @GroupId);";

	public static string InsertProductSize = @"
                        INSERT INTO ""ProductSizes"" (""ProductId"", ""SizeId"", ""QuantityInStock"")
                        VALUES (@ProductId, @SizeId, @QuantityInStock);";

	public static string InsertProduct = @"
                INSERT INTO ""Products"" (""BrandId"", ""Title"", ""Photo"", ""Price"", ""Description"", ""IsDeleted"") 
                VALUES (@BrandId, @Title, @Photo, @Price, @Description, @IsDeleted)
				RETURNING ""Id"";";

}
