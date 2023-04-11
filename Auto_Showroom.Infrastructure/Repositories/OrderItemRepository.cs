using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    public Task<List<OrderItem>> GetOrderItem()
    {
        throw new NotImplementedException();
    }
}