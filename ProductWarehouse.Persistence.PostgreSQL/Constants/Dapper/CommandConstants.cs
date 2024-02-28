namespace ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
public static class CommandConstants
{
	public static string UpdateQuantityInStockCommand = @"
            UPDATE ""ProductSizes""
            SET ""QuantityInStock"" = @QuantityInStock
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

	public static string DeleteProductSizeCommand = @"
            DELETE FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";
	
    public static string DeleteProductGroupCommand = @"
            DELETE FROM ""ProductGroups""
            WHERE ""ProductId"" = @ProductId AND ""GroupId"" = @GroupId";

}
