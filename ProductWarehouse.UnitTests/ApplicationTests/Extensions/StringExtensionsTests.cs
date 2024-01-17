using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Domain.Entities;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("Another example", "example", "Another <em>example</em>")]
        [InlineData("", "keyword", "")]
        [InlineData("Text without keywords", "", "Text without keywords")]
        [InlineData(null, "keyword", null)]
        [InlineData(null, null, null)]
        public void HighlightKeywords_ShouldHighlightKeywords(string inputText, string highlightKeywords, string expectedOutput)
        {
            // Arrange
            // No need for additional arrangements

            // Act
            var result = inputText.HighlightKeywords(highlightKeywords);

            // Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void FindMostCommonWords_ShouldReturnMostCommonWords()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Description = "Lorem ipsum dolor sit amet consectetur" },
                new Product { Description = "Sed do eiusmod tempor incididunt ut labore" },
                // Add more products with different descriptions
            };

            // Act
            var result = StringExtensions.FindMostCommonWords(products);

            // Assert
            // Add assertions based on the expected most common words
            // For example:
            Assert.Contains("incididunt", result);
            Assert.Contains("sit", result);
        }
    }
}