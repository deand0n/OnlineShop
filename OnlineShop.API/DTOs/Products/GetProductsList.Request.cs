using OnlineShop.API.DTOs.Pagination;

namespace OnlineShop.API.DTOs.Products;

public class GetProductsListRequest : Pageable
{
    public string SearchQuery;

    public GetProductsListRequest(Pageable pageable) : base(pageable)
    {
    }
}
