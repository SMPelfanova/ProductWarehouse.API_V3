namespace ProductWarehouse.Application.Features.Queries.GetProducts;

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Infrastructure.Interfaces;

public class GetProductsHandler : IRequestHandler<ProductsQuery, IEnumerable<ProductDto>>
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

        public async Task<IEnumerable<ProductDto>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetProductsAsync(request.MinPrice, request.MaxPrice, request.Size).Result.ToList();
            if (products.Count <= 0)
            {
                _logger.LogInformation("No products found for filter: ");
                return null;
            }
            //var response = new ProductFilterResponse()
            //{
            //    Products = _mapper.Map<IEnumerable<ProductResponse>>(products),
            //    Filter = new FilterResponse()
            //    {
            //        MinPrice = products.Min(p => p.Price),
            //        MaxPrice = products.Max(p => p.Price),
            //        Sizes = products.SelectMany(o => o.Sizes).Distinct().ToArray(),
            //        CommonWords = _commonWordsFinder.FindMostCommonWords(products)
            //    }
            //};

            if (!string.IsNullOrEmpty(request.Highlight))
            {
               // HighlightKeywords(response.Products, request.Highlight);
            }

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        //private void HighlightKeywords(IEnumerable<ProductResponse> products, string highlight)
        //{
        //    foreach (var product in products)
        //    {
        //        product.Description = _keywordHighlighter.HighlightKeywords(product.Description, highlight);
        //    }
        //}

   
}
