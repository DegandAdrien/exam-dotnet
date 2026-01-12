using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspireApp.Persistence.product;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.id);
        builder.Property(t => t.name).IsRequired();
        builder.Property(t => t.price).IsRequired();
        builder.Property(t => t.stock).IsRequired();
    } 
}