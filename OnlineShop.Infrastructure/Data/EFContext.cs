using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Base;

namespace OnlineShop.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {
        
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        CheckEntityState();
        
        return base.SaveChangesAsync(cancellationToken);        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<BaseEntity>().HasQueryFilter(b => !b.IsDeleted);
    }

    private void CheckEntityState()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var baseEntity = entry.Entity as BaseEntity;
            if (baseEntity == null)
            {
                continue;
            }
            
            if (entry.State == EntityState.Added)
            {
                baseEntity.CreateDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdateDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.UpdateDate = DateTime.UtcNow;
                baseEntity.DeleteDate = DateTime.UtcNow;
                baseEntity.IsDeleted = true;
            }
        }
    }
}