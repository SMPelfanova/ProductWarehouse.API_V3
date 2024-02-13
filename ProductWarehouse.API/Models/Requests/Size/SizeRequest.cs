namespace ProductWarehouse.API.Models.Requests;

public class SizeRequest
{
    public Guid Id { get; set; }
    public int QuantityInStock { get; set; }
}