using Microsoft.EntityFrameworkCore;
using ProductService.Core.Entities;

namespace ProductService.Infrastructure.Data;
public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    // Fluent API configurations if necessary
}
