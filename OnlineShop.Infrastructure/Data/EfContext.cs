using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;
using OnlineShop.Domain.Base;
using OnlineShop.Infrastructure.Data.EntitiesConfig;
using OnlineShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

namespace OnlineShop.Infrastructure.Data;

public sealed class EfContext : DbContext
{
    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        CheckEntityState();
        
        return base.SaveChangesAsync(cancellationToken);        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=online_shop;Username=student;Password=admin");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        // modelBuilder.Entity<BaseEntity>().HasQueryFilter(b => !b.IsDeleted);
        
        // InitializeBaseEntity(modelBuilder);
        
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new ImageConfiguration().Configure(modelBuilder.Entity<Image>());
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
                baseEntity.Id = Guid.NewGuid();
                baseEntity.CreateDate = DateTime.UtcNow;
                baseEntity.UpdateDate = DateTime.UtcNow;
                baseEntity.IsDeleted = false;
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