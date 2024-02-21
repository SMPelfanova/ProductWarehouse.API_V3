namespace ProductWarehouse.Application.Models.Basket;

public class BasketDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public List<BasketLineDto> BasketLines { get; set; }
}