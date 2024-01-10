using MediatR;
using ProductWarehouse.Application.Responses;

namespace ProductWarehouse.Application.Queries
{
    public class ProductsQuery : IRequest<ProductFilterResponse>
    {
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = 0;
        public string Size { get; set; } = string.Empty;
        public string Highlight { get; set; } = string.Empty;
    }
}
