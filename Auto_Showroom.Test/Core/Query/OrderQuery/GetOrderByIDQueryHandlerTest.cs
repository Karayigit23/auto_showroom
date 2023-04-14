using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderQuery;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Query.OrderQuery;

public class GetOrderByIDQueryHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<ILogger<GetOrderByIDHandle>> _logger;
    private readonly GetOrderByIDHandle _handler;

    public GetOrderByIDQueryHandlerTest()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _logger = new Mock<ILogger<GetOrderByIDHandle>>();
        _handler = new GetOrderByIDHandle(_orderRepository.Object, _logger.Object);
    }
    [SetUp]
    public void SetUp()
    {
        _orderRepository.Invocations.Clear();
    }
    
    [Test] 
    public async Task handle_when_order_is_not_exist_then_throw_exception()
        {
            var command = new GetOrderByIDQuery()
            {
                Id = 1
            };
            _orderRepository.Setup(p => p.GetById(command.Id)).ReturnsAsync((Order)null);
            
            Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, default));
            _orderRepository.Verify(p=>p.GetById(command.Id),Times.Once);
        }
    
   
    
}