namespace ProductWarehouse.API.Models.Responses.Basket;

public class BasketResponse
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public List<BasketLineResponse> BasketLines { get; set; }
}