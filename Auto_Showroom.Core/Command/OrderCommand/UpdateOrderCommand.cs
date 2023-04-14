using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class UpdateOrderCommand:IRequest<Order>
{
    public int Id { get; set; }
    public string PersonName { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    

}
public class UpdateOrderCommandHandle : IRequestHandler<UpdateOrderCommand,Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<UpdateOrderCommandHandle> _logger;
 
    public  UpdateOrderCommandHandle(IOrderRepository orderRepository,ILogger<UpdateOrderCommandHandle> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;

    }
    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"Called with OrderId{request.Id}and order update");
        var order = await _orderRepository.GetById(request.Id);

        if (order == null)
        {
            _logger.LogInformation(message:$"Order with Id{request.Id} not found");
            throw new InvalidOperationException($"Order with id {request.Id} not found.");
        }

        order.PersonName = request.PersonName;
        order.OrderDate = request.OrderDate;
        order.OrderItems = request.OrderItems;

        await _orderRepository.UpdateOrder(order);

        return order;
    }
}