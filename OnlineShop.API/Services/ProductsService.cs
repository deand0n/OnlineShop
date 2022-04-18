using System.Linq.Expressions;
using OnlineShop.API.DTOs.Pagination;
using OnlineShop.API.DTOs.Products;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class ProductsService : BaseService
{
    private readonly IRepository<Product> _productRepository;
    
    public ProductsService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
    }

    public async Task<AddProductResponse> AddProduct(AddProductRequest request)
    {
        return null;
    }

    public async Task<Page<GetProductsListResponse>> GetProductsList(GetProductsListRequest request)
    {
        Expression<Func<Product, bool>> closestToSearchQuery = product => product.Name.Contains(request.SearchQuery) || 
                                                                         product.Description.Contains(request.SearchQuery);
        
        var products = await _productRepository.ListAsync(closestToSearchQuery);
        var totalItemsCount = await _productRepository.CountAsync(closestToSearchQuery);
        
        var productsResponse = products.Select(product => new GetProductsListResponse(product));

        return new Page<GetProductsListResponse>(productsResponse, totalItemsCount, request);
    }
}