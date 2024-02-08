namespace ProductWarehouse.API.Models.Requests.Basket;
public class UpdateBasketLineRequest
{ 
    public Guid ProductId {  get; set; }
    public int Quantity { get; set; }
    public Guid SizeId { get; set; }
}
