using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Core.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrder();
    Task<Order> GetById(int Id);
    Task AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Order order);
}