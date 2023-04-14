using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command.OrdeCommand;

public class CreateOrderCommandHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<CreateOrderHandler>> _logger;
    private readonly CreateOrderHandler _handle;
    public CreateOrderCommandHandlerTest()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<CreateOrderHandler>>(); 
        _handle = new CreateOrderHandler(_orderRepository.Object,_carRepository.Object,_logger.Object); 
    }
    [SetUp]
    public void SetUp()
    {
        _orderRepository.Invocations.Clear();
        _carRepository.Invocations.Clear();
    }
    [Test]
    public async Task  handle_when_order_is_not_exist_then_throw_exception()
    {
        //given
        var command = new CreateOrderCommand
        {
            
            PersonName = "Faruk",
            OrderDate = DateTime.Now,
            OrderItems = new List<OrderItem>()
            
            
        };
        
        //when //then
        Assert.ThrowsAsync<Exception>(async () => await _handle.Handle(command, default));
        _orderRepository.Verify(p => p.AddOrder(It.IsAny<Order>()), Times.Never);
        
    }
}
