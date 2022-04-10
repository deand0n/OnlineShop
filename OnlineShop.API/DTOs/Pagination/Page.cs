using OnlineShop.Domain.Base;

namespace OnlineShop.API.DTOs.Pagination;

public class Page<T> : Pageable where T : BaseEntity
{
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T?> Items { get; set; }

    public Page(IEnumerable<T?> items, int totalItems, Pageable pageable) : base(pageable)
    {
        Items = items;
        TotalItems = totalItems;
        TotalPages = TotalItems / PageSize;
    }
}