namespace OnlineShop.API.DTOs.Pagination;

public class Page<T> : Pageable
{
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public IEnumerable<T?> Items { get; set; }

    public Page(IEnumerable<T> items, int totalItemsCount, Pageable pageable) : base(pageable)
    {
        Items = items;
        TotalItemsCount = totalItemsCount;
        TotalPages = TotalItemsCount / PageSize;
    }
}