namespace ProductWarehouse.Application.Utilities
{
    public interface IKeywordHighlighter
    {
        string HighlightKeywords(string inputText, string highlightKeywords);
    }
}
