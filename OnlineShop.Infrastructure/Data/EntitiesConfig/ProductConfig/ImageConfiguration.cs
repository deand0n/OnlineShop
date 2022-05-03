using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Infrastructure.Data.EntitiesConfig.ProductConfig;

public class ImageConfiguration : BaseConfiguration<Image>
{
    public override void Configure(EntityTypeBuilder<Image> builder)
    {
        base.Configure(builder);
        
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
    }
}