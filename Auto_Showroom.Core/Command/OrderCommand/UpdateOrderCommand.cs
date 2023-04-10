using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class UpdateOrderCommand:IRequest<Order>
{
    public int OrderId { get; set; }
    public string PersonName { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    

}
public class UpdateOrderCommandHandle : IRequestHandler<UpdateOrderCommand,Order>
{
    private readonly IOrderRepository _orderRepository;
 
    public  UpdateOrderCommandHandle(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
   
    }
    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId);

        if (order == null)
        {
            throw new InvalidOperationException($"Order with id {request.OrderId} not found.");
        }

        order.PersonName = request.PersonName;
        order.OrderDate = request.OrderDate;
        order.OrderItems = request.OrderItems;

        await _orderRepository.UpdateOrder(order);

        return order;
    }
}