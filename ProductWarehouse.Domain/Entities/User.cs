namespace ProductWarehouse.Domain.Entities;

public class User : Entity
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string Phone { get; set; }
	public string Address { get; set; }
	public bool IsDeleted { get; set; }
	public ICollection<Order> Orders { get; set; }
	public ICollection<UserRole> UserRoles { get; set; }
	public Baskets Basket { get; set; }
}