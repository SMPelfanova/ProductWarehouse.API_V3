namespace ProductWarehouse.Infrastructure.Configuration;

public class MockyClientOptions
{
    public const string MockyClient = "MockyClient";
    public string BaseUrl { get; set; } = string.Empty;
    public string ProductUrl { get; set; } = string.Empty;
}
