namespace ProductWarehouse.Domain.Entities;
public class Basket
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }

}
