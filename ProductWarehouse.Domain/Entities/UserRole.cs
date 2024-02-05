namespace ProductWarehouse.Domain.Entities;
public class UserRole
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<User> Users { get; set; } = new List<User>();
}
