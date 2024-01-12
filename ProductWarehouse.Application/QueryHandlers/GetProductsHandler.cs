using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Application.Utilities;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Repositories;

namespace ProductWarehouse.Application.QueryHandlers
{
    public class GetProductsHandler : IRequestHandler<ProductsQuery, ProductFilterResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsHandler> _logger;
        private readonly IKeywordHighlighter _keywordHighlighter;
        private readonly ICommonWordsFinder _commonWordsFinder;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsHandler> logger, IKeywordHighlighter keywordHighlighter, ICommonWordsFinder commonWordsFinder)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _keywordHighlighter = keywordHighlighter;
            _commonWordsFinder = commonWordsFinder;
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
                    CommonWords = _commonWordsFinder.FindMostCommonWords(products)
                }
            };

            if (!string.IsNullOrEmpty(request.Highlight))
            {
                HighlightKeywords(response.Products, request.Highlight);
            }

            return response;
        }

        private void HighlightKeywords(IEnumerable<ProductResponse> products, string highlight)
        {
            foreach (var product in products)
            {
                product.Description = _keywordHighlighter.HighlightKeywords(product.Description, highlight);
            }
        }

    }
}
