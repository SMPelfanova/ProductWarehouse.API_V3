namespace ProductWarehouse.Application.Utilities
{
    public class KeywordHighlighter : IKeywordHighlighter
    {
        public string HighlightKeywords(string inputText, string highlightKeywords)
        {
            if (string.IsNullOrEmpty(inputText) || string.IsNullOrEmpty(highlightKeywords))
            {
                return inputText;
            }

            string[] keywords = highlightKeywords.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyword in keywords)
            {
                string[] words = inputText.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (string.Equals(words[i], keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        words[i] = $"<em>{words[i]}</em>";
                    }
                }
                inputText = string.Join(' ', words);
            }

            return inputText;
        }
    }
}
