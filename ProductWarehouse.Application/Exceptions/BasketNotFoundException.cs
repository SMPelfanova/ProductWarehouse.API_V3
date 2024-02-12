namespace ProductWarehouse.Application.Exceptions;
public class BasketNotFoundException : Exception
{
    public BasketNotFoundException(string message) : base(message)
    {
    }
}