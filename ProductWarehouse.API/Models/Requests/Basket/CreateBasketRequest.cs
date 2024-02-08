namespace ProductWarehouse.API.Models.Requests.Basket;

public class CreateBasketRequest
{
    public Guid UserId { get; set; }

    public List<BasketLineRequest> BasketLines { get; set; }
}
