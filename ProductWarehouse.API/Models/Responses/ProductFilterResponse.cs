using MediatR;

namespace ProductWarehouse.API.Models.Responses;

public class ProductFilterResponse
{
    public FilterResponse Filter { get; set; } = new FilterResponse();
    public IEnumerable<ProductResponse> Products { get; set; } = Enumerable.Empty<ProductResponse>();
}
