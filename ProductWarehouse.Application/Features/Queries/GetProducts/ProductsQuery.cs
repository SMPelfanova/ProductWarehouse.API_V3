using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.GetProducts
{
    public class ProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = 0;
        public string Size { get; set; } = string.Empty;
        public string Highlight { get; set; } = string.Empty;
    }
}
