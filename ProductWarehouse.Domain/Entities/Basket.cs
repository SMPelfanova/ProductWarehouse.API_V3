namespace ProductWarehouse.Domain.Entities;
public class Basket : Entity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<BasketLine> BasketLines { get; set; }

}
