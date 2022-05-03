using OnlineShop.Domain.Base.Pagination;

namespace OnlineShop.API.DTOs.Products;

public class GetProductsListRequest : Pageable
{
    public string SearchQuery { get; set; } = "";

    public GetProductsListRequest(Pageable pageable) : base(pageable)
    {
    }

    public GetProductsListRequest()
    {
        
    }
}
