using ProductWarehouse.Domain.Entities;
using System.Text.RegularExpressions;

namespace ProductWarehouse.Application.Utilities
{
    public class CommonWordsFinder: ICommonWordsFinder
    {
        public string[] FindMostCommonWords(IEnumerable<Product> products)
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
}
