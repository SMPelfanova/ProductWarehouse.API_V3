namespace ProductWarehouse.API.Models.Requests;

/// <summary>
/// Represents a query object for filtering products.
/// </summary>
public class FilterProductsRequest
{
    /// <summary>
    /// The minimum price for filtering products.
    /// </summary>
    public decimal? MinPrice { get; set; } = 0;

    /// <summary>
    /// The maximum price for filtering products.
    /// </summary>
    public decimal? MaxPrice { get; set; } = 0;

    /// <summary>
    /// The size for filtering products.
    /// </summary>
    public string Size { get; set; } = string.Empty;

    /// <summary>
    /// Comma-separated list of highlights for filtering products.
    /// </summary>
    public string Highlight { get; set; } = string.Empty;
}