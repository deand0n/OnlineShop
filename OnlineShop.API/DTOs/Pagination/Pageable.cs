namespace OnlineShop.API.DTOs.Pagination;

public class Pageable
{
    public int CurrentPageNumber { get; set; }
    public int PageSize { get; set; }
    // public SortBy SortBy { get; set; }

    protected Pageable(Pageable pageable)
    {
        const int defaultPageSize = 50;

        CurrentPageNumber = pageable.CurrentPageNumber;
        PageSize = pageable.PageSize == 0 ? defaultPageSize : pageable.PageSize;
        // SortBy = pageable.SortBy;
    }

    protected Pageable()
    {
        
    }
}