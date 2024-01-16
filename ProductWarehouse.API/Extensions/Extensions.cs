using ProductWarehouse.Domain.Entities;
using System.Text.RegularExpressions;

namespace ProductWarehouse.API.Extensions;

public static class Extensions
{
    public static string HighlightKeywords(string inputText, string highlightKeywords)
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

    public static string[] FindMostCommonWords(IEnumerable<Product> products)
    {
        var allWords = products
            .SelectMany(p => Regex.Replace(p.Description.ToLowerInvariant(), "[^a-zA-Z ]", "", RegexOptions.Compiled)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        var wordFrequency = allWords.GroupBy(word => word)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key, StringComparer.OrdinalIgnoreCase)
            .Skip(5)
            .Take(10)
            .ToDictionary(group => group.Key, group => group.Count());

        return wordFrequency.Keys.ToArray();
    }

}
