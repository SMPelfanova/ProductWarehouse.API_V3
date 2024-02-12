namespace ProductWarehouse.Application.Exceptions;
public class ProductSizeNotAvailableException : Exception
{
	public ProductSizeNotAvailableException(string message) : base(message)
	{
	}
}
