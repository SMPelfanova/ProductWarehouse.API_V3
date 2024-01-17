
namespace ProductWarehouse.Application.Models
{
    public class ProductsFilterDto
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public IEnumerable<string> Sizes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> CommonWords { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProductDto> Products { get; set; } = Enumerable.Empty<ProductDto>();
    }
}
