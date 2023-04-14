using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command.OrdeCommand;

public class DeleteOrderCommandHandlerTest
{
   

    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<ILogger< DeleteOrderCommandHandle>> _logger;
    private readonly  DeleteOrderCommandHandle _handler;
    
    public DeleteOrderCommandHandlerTest ()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _logger = new Mock<ILogger<DeleteOrderCommandHandle>>();
        _handler = new DeleteOrderCommandHandle(_orderRepository.Object, _logger.Object);
    }
    [SetUp]
    public void SetUp()
    {
        _orderRepository.Invocations.Clear();
       
    }

    [Test]
    public async Task handle_when_car_exist_then_delete_car()
    {
        //given
        var command = new DeleteOrderCommand
        {
            Id = 1,
        };
        _orderRepository.Setup(p => p.GetById(command.Id)).ReturnsAsync(new Order{Id=command.Id});
        
        await _handler.Handle(command, default);
        _orderRepository.Verify(p=>p.GetById(command.Id),Times.Once);
        _orderRepository.Verify(p=>p.DeleteOrder(It.IsAny<Order>()),Times.Once);
    }
    [Test]
    public async Task handle_when_order_is_not_exist_then_throw_exception()
    {
        //given
        var command = new DeleteOrderCommand()
        {
            Id = 1,
           
        };
        _orderRepository.Setup(p => p.GetById(command.Id)).ReturnsAsync((Order)null);


        //when  //then
        Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, default));
        _orderRepository.Verify(p=>p.GetById(command.Id),Times.Once);
        _orderRepository.Verify(p=>p.DeleteOrder(It.IsAny<Order>()),Times.Never);
    }

}










