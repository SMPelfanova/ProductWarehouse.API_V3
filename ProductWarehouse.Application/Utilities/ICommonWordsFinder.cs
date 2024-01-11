using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Utilities
{
    public interface ICommonWordsFinder
    {
        string[] FindMostCommonWords(IEnumerable<Product> products);
    }
}
