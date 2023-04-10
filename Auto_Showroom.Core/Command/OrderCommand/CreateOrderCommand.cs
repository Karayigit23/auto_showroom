using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using System.Collections.Generic;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class CreateOrderCommand:IRequest<Order>
{
    public string PersonName { get; set; } 
    public int CarId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public List<OrderItem> OrderItems { get; set; }
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
       
        var car = await _carRepository.GetCarById(request.CarId);

        var order = new Order
        {
            PersonName = request.PersonName,
            OrderDate = request.OrderDate,
            CarId = request.CarId,
            Car = car,
            OrderItems = request.OrderItems
        };

        await _orderRepository.AddOrder(order);

        return order;

    }
}



    
