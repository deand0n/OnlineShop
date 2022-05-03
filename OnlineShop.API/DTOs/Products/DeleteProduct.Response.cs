namespace OnlineShop.API.DTOs.Products;

public class DeleteProductResponse
{
    public bool IsDeleted { get; set; }
    
    public DeleteProductResponse(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}