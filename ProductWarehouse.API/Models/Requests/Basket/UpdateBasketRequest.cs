namespace ProductWarehouse.API.Models.Requests.Basket;

public class UpdateBasketRequest
{
	public Guid UserId { get; set; }
	public UpdateBasketLineRequest BasketLine { get; set; }
}