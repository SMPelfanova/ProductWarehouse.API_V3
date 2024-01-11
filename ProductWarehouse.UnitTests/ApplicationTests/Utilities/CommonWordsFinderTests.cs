using ProductWarehouse.Application.Utilities;
using ProductWarehouse.Domain.Entities;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests.Utilities
{
    public class CommonWordsFinderTests
    {
        [Fact]
        public void FindMostCommonWords_NoProducts_ReturnsEmptyArray()
        {
            // Arrange
            var commonWordsFinder = new CommonWordsFinder();
            var products = new List<Product>();

            // Act
            var result = commonWordsFinder.FindMostCommonWords(products);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindMostCommonWords_SingleProduct_ReturnsCommonWords()
        {
            // Arrange
            var commonWordsFinder = new CommonWordsFinder();
            var products = new List<Product>
            {
                new Product { Description = "This is a sample product description" }
            };

            // Act
            var result = commonWordsFinder.FindMostCommonWords(products);

            // Assert
            Assert.Equal(new[] { "this" }, result, StringComparer.OrdinalIgnoreCase);
        }

        [Fact]
        public void FindMostCommonWords_MultipleProducts_ReturnsCommonWords()
        {
            // Arrange
            var commonWordsFinder = new CommonWordsFinder();
            var products = new List<Product>
            {
                new Product { Description = "This is a sample product description" },
                new Product { Description = "Another description with common words" }
            };

            // Act
            var result = commonWordsFinder.FindMostCommonWords(products);

            // Assert
            Assert.Contains("product", result, StringComparer.OrdinalIgnoreCase);
            Assert.Contains("sample", result, StringComparer.OrdinalIgnoreCase);
            // Add more assertions based on the expected common words
        }

        // Add more test cases as needed
    }
}
