namespace OnlineShop.Domain.Base.Pagination;

public class Pageable
{
    // counting from 0
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    protected Pageable(Pageable pageable)
    {
        CurrentPage = pageable.CurrentPage;
        PageSize = pageable.PageSize;
    }

    protected Pageable()
    {
        
    }
}