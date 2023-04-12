using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Core.Interfaces;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetOrderItem();
    Task<OrderItem> GetOrderItemById(int Id);
    
}