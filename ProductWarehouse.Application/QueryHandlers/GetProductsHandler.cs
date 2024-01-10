using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Repositories;
using System.Text.RegularExpressions;

namespace ProductWarehouse.Application.QueryHandlers
{
    public class GetProductsHandler : IRequestHandler<ProductsQuery, ProductFilterResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsHandler> _logger;
        public GetProductsHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductFilterResponse> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync(request.MinPrice, request.MaxPrice, request.Size);
            if (products == null || !products.Any())
            {
                _logger.LogInformation("No products found for filter: ");
                return null;
            }
            var response = new ProductFilterResponse()
            {
                Products = _mapper.Map<IEnumerable<ProductResponse>>(products),
                Filter = new FilterResponse()
                {
                    MinPrice = products.Min(p => p.Price),
                    MaxPrice = products.Max(p => p.Price),
                    Sizes = products.SelectMany(o => o.Sizes).Distinct().ToArray(),
                    CommonWords = FindMostCommonWords(products)
                }
            };

            if (!string.IsNullOrEmpty(request.Highlight))
            {
                ReplaceDescriptions(response.Products, request.Highlight);
            }

            return response;
        }

        private string[] FindMostCommonWords(IEnumerable<Product> products)
        {
            var allWords = products
                .SelectMany(p => Regex.Replace(p.Description.ToLowerInvariant(), "[^a-zA-Z ]", "", RegexOptions.Compiled).Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            var wordFrequency = allWords.GroupBy(word => word)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key, StringComparer.OrdinalIgnoreCase)
                .Skip(5).Take(10)
                .ToDictionary(group => group.Key, group => group.Count());

            return wordFrequency.Keys.ToArray();
        }

        private void ReplaceDescriptions(IEnumerable<ProductResponse> products, string highlights)
        {
            if (!string.IsNullOrEmpty(highlights))
            {
                foreach (var product in products)
                {
                    product.Description = HighlightKeywords(product.Description, highlights);
                }
            }
        }

        private string HighlightKeywords(string description, string highlight)
        {
            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(highlight))
            {
                return description;
            }

            string[] highlightList = highlight.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyword in highlightList)
            {
                string[] words = description.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (string.Equals(words[i], keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        words[i] = $"<em>{words[i]}</em>";
                    }
                }

                description = string.Join(' ', words);
            }

            return description;
        }
    }
}
