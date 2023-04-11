using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using System.Collections.Generic;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class CreateOrderCommand:IRequest<Order>
{
    public string PersonName { get; set; } 
   
    public int Quantity { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    
    
    public DateTime OrderDate { get; set; }

}

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICarRepository _carRepository;
   

    public CreateOrderHandler(IOrderRepository orderRepository,ICarRepository carRepository)
    {
        _orderRepository = orderRepository;
        _carRepository = carRepository;
    }
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

      // sorun => orderItem Id yi order a ekleyemiyorum çünkü orderItemı orderı yaratırken yaratıyorum ve daha yaratılmamış Itemin ıd olamayacağı için ıd null kalıyor

        
        var order = new Order
        {
            PersonName = request.PersonName,
            OrderDate = request.OrderDate,
            OrderItems = new List<OrderItem>()
            //order içinde birden fazla car id gelicek ve aynı zamanda miktar bu miktarlar la order item oluştur ve db kayıt et
        };
        foreach (var orderItem in request.OrderItems)
        {
            var orderıt = await _carRepository.GetCarById(orderItem.CarId);

            var newOrderItem = new OrderItem()
            {
                CarId = orderItem.CarId,
                Quantity = orderItem.Quantity
            };
            order.OrderItems.Add(newOrderItem);
        }
       
        await _orderRepository.AddOrder(order);

        return order;

    }
}



    
