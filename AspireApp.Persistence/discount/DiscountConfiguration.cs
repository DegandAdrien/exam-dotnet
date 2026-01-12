using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspireApp.Persistence.discount;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(t => t.code);
        builder.Property(t => t.code).IsRequired();
        builder.Property(t => t.value).IsRequired();
    } 
}