using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        
        builder.Property(product => product.Name) 
            .HasColumnName("name")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasColumnName("description")
            .HasMaxLength(500);
        
        builder.Property(product => product.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.Property(product => product.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        // copy & paste for every entity 
        // BEGIN
        builder.HasQueryFilter(entity => !entity.IsDeleted);
        
        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(entity => entity.CreateDate)
            .HasColumnName("create_date")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        
        builder.Property(entity => entity.UpdateDate)
            .HasColumnName("update_date")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        
        builder.Property(entity => entity.DeleteDate)
            .HasColumnName("delete_date")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(entity => entity.IsDeleted)
            .HasColumnName("is_deleted")
            .HasColumnType("boolean")
            .IsRequired();
        // END

        builder.HasMany(product => product.Images)
            .WithOne(image => image.Product)
            .HasForeignKey(image => image.ProductId)
            .IsRequired();
    }
}