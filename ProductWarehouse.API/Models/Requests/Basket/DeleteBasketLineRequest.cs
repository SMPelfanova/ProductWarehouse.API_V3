using ProductWarehouse.API.Models.Requests.Base;

namespace ProductWarehouse.API.Models.Requests.Basket;

public class DeleteBasketLineRequest : BaseRequestUserId
{
	public Guid BasketLineId { get; set; }
}
