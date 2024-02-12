namespace ProductWarehouse.Application.Exceptions;
public class GroupNotFoundException : Exception
{
    public GroupNotFoundException(string message) : base(message)
    {
    }
}