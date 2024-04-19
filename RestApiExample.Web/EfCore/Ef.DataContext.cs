using Microsoft.EntityFrameworkCore;

namespace RestApiExample.Web.EfCore;

public class EfDataContext : DbContext
{
    public EfDataContext(DbContextOptions<EfDataContext> options): base(options) {}


    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }
}
