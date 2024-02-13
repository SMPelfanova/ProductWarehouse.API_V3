using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Factories;

public class EntityFactory : AbstractFactory<object>
{
	public override object Create(string type)
	{
		switch (type)
		{
			case nameof(BasketLineDto):
				return new BasketLineDto();
			case nameof(OrderLineDto):
				return new OrderLineDto();
			default:
				throw new ArgumentException($"Unsupported type: {type}");
		}
	}
}