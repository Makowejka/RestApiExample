using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) {}


    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }
}
