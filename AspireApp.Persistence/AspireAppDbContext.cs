using AspireApp.Persistence.discount;
using AspireApp.Persistence.product;
using Microsoft.EntityFrameworkCore;

namespace AspireApp.Persistence;

public class AspireAppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    
    public AspireAppDbContext(DbContextOptions<AspireAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
        new DiscountConfiguration().Configure(modelBuilder.Entity<Discount>());
        base.OnModelCreating(modelBuilder);
    }
}