using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Car { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Order>Order { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); 

        base.OnModelCreating(modelBuilder);
    }
}