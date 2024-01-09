using MediatR;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Repositories;

namespace ProductWarehouse.Application.QueryHandlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, ProductFilterResponse>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductFilterResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync(request.MinPrice, request.MaxPrice, request.Size, request.Highlight);
            
            var response = new ProductFilterResponse()
            {
                //todo: add mapper
                //Products = products,
                Filter = new FilterResponse()
                {

                }
            };

            return response;
        }
    }
}
