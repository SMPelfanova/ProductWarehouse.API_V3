using System.ComponentModel.DataAnnotations;

namespace ProductWarehouse.API.QueryParameters
{
    /// <summary>
    /// Represents a query object for filtering products.
    /// </summary>
    public class ProductsFilter
    {
        /// <summary>
        /// The minimum price for filtering products.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "MinPrice must be a non-negative value.")]
        public decimal? MinPrice { get; set; } = 0;

        /// <summary>
        /// The maximum price for filtering products.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "MaxValue must be a non-negative value.")]
        public decimal? MaxPrice { get; set; } = 0;

        /// <summary>
        /// The size for filtering products.
        /// </summary>
        [MaxLength(255, ErrorMessage = "Size parameter cannot exceed 255 characters.")]
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Comma-separated list of highlights for filtering products.
        /// </summary>
        [MaxLength(255, ErrorMessage = "Highlight parameter cannot exceed 255 characters.")]
        public string Highlight { get; set; } = string.Empty;
    }
}