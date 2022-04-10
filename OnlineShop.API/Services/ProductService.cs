using OnlineShop.API.DTOs.Pagination;
using OnlineShop.API.DTOs.Product;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class ProductService : BaseService
{
    public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {}

    public async Task<Page<GetProductsListResponse>> GetProductsList(GetProductsListRequest request)
    {
        // var products = await UnitOfWork.ProductRepository.ListAsync(product => product.Name.Length > 0);
        
        // return null;
        throw new NotImplementedException();
    }
}