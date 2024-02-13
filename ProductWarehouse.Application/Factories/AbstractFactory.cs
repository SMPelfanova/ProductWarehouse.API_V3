namespace ProductWarehouse.Application.Factories;
public abstract class AbstractFactory<T>
{
	public abstract T Create(string type);

	public T Create(Type type)
	{
		return Create(type.Name);
	}
}