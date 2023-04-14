using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure.Repositories;

public class OrderRepository:IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<List<Order>> GetOrder()
    {
        return _context.Order.ToListAsync();
    }

    public Task<Order> GetById(int Id)
    {
        return _context.Order.Where(p => p.Id == Id).FirstOrDefaultAsync();
    }

    public async Task AddOrder(Order order)
    {
        await _context.Order.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrder(Order order)
    {
        _context.Order.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrder(Order order)
    {
        var exOrder = await _context.Order
            .FirstOrDefaultAsync(o => o.Id == order.Id); 

            if (exOrder != null)
            {
                _context.Order.Remove(exOrder); 
                await _context.SaveChangesAsync(); 
            }
        
    }
}