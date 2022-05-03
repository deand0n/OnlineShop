using System.Linq.Expressions;
using AutoMapper;
using OnlineShop.API.DTOs.Products;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;
using OnlineShop.Domain.Base.Pagination;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class ProductsService : BaseService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductsService(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
        _mapper = mapper;
    }
    
    public async Task<AddProductResponse> AddAsync(AddProductRequest request)
    {
        var product = Product.Create(
            request.Name, 
            request.Description, 
            request.Price, 
            request.Quantity, 
            request.Images);
        
        await _productRepository.AddAsync(product);
        await UnitOfWork.SaveChangesAsync();

        var response = _mapper.Map<Product, AddProductResponse>(product);

        return response;
    }

    public async Task<Page<GetProductsListResponse>> GetPaginatedListAsync(GetProductsListRequest request)
    {
        var searchQuery = request.SearchQuery.Trim().ToLower();
        
        Expression<Func<Product, bool>> closestToSearchQuery = product => 
            product.Name.Contains(searchQuery) || 
            product.Description.Contains(searchQuery);
        
        var products = await _productRepository.PaginatedListAsync(closestToSearchQuery, request);
        
        var productsResponse = _mapper.Map<IEnumerable<GetProductsListResponse>>(products);

        return new Page<GetProductsListResponse>(productsResponse, products.Count, request);
    }
    
    public async Task<GetProductByIdResponse?> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        
        var response = _mapper.Map<GetProductByIdResponse?>(product);

        return response;
    }

    public async Task<UpdateProductResponse?> UpdateAsync(UpdateProductRequest request, Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }
        
        product = product.Update(
            product,
            request.Name, 
            request.Description, 
            request.Price, 
            request.Quantity, 
            request.Images);
        
        await _productRepository.UpdateAsync(product);
        await UnitOfWork.SaveChangesAsync();
        
        var response = _mapper.Map<UpdateProductResponse>(product);

        return response;
    }

    public async Task<DeleteProductResponse?> DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return null;
        }
        
        bool response = await _productRepository.DeleteAsync(product);
        await UnitOfWork.SaveChangesAsync();
        
        return new DeleteProductResponse(response);
    }
}