using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("images");

        builder.Property(image => image.Url)
            .HasColumnName("url")
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(image => image.Alt)
            .HasColumnName("alt")
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(image => image.ProductId)
            .HasColumnName("product_id")
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
    }
}