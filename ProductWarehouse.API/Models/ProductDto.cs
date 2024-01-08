namespace ProductWarehouse.API.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> Sizes { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
    }
}
