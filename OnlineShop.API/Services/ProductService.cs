using System.Linq.Expressions;
using OnlineShop.API.DTOs.Pagination;
using OnlineShop.API.DTOs.Products;
using OnlineShop.Domain.Base;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.ProductAggregate;

namespace OnlineShop.API.Services;

public class ProductService : BaseService
{
    IRepository<Product> _productRepository;
    
    public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
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