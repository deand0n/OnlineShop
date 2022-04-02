using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }
}