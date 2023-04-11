using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;

    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<OrderItem>> GetOrderItem()
    {
        return _context.OrderItem.ToListAsync();
    }
}