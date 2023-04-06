using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure;

public class TestDbContext:DbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Car> Car { get; set; }
    public DbSet<OrderItem> Orderİtem { get; set; }
    public DbSet<Order>Order { get; set; }
}