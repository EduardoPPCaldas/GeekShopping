using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context;

public class MySQLContext : DbContext
{
    public MySQLContext()
    {
        
    }

    public MySQLContext(DbContextOptions<MySQLContext> options): base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<Product> Products => Set<Product>();
}
