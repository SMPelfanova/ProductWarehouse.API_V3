namespace ProductWarehouse.Application.Exceptions;
public class SizeNotFoundException : Exception
{
    public SizeNotFoundException(string message) : base(message)
    {
    }
}