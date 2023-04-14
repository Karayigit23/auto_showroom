using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command.OrdeCommand;

public class UpdateOrderCommandHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<ILogger<UpdateOrderCommandHandle>> _logger;
    private readonly UpdateOrderCommandHandle _handle;

    public UpdateOrderCommandHandlerTest()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _logger = new Mock<ILogger<UpdateOrderCommandHandle>>();
        _handle = new UpdateOrderCommandHandle(_orderRepository.Object, _logger.Object);
    }
    [SetUp]
    public void SetUp()
    {
        _orderRepository.Invocations.Clear();
    }
    [Test]
    public async Task handle_when_order_exist_then_update_order()
    {
        //given
        var command = new UpdateOrderCommand
        {
            Id = 1,
            PersonName = "Hakan",
            OrderDate =  DateTime.Now,
            OrderItems = new List<OrderItem>()
        };

        var order= new Order
        {
            Id = 1,
            PersonName = "Aslı",
            OrderDate = DateTime.Now,
            OrderItems = new List<OrderItem>()
              
        };
        _orderRepository.Setup(p => p.GetById(command.Id)).ReturnsAsync(order);


        //when
        await _handle.Handle(command, default);
        
        
        //then
        order.PersonName.Should().Be(command.PersonName);
        order.OrderDate.Should().Be(command.OrderDate);
        



        _orderRepository.Verify(p=>p.GetById(command.Id),Times.Once);
        _orderRepository.Verify(p=>p.UpdateOrder(It.IsAny<Order>()),Times.Once);
    }
}