using OnlineShop.API.DTOs.Pagination;

namespace OnlineShop.API.DTOs.Product;

public class GetProductsListRequest : Pageable
{
    public string SearchQuery;

    public GetProductsListRequest(Pageable pageable) : base(pageable)
    {
    }
}
