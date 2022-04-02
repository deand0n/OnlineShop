using OnlineShop.API.DTOs;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class ProductService : BaseService
{
    ProductService(IUnitOfWork unitOfWork) : base(unitOfWork) {}

    public async Task<GetProductsListResponse?> GetProductsList(GetProductsListRequest products)
    {
        return null;
    }
}