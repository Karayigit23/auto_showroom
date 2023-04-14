using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderQuery;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Query.OrderQuery;

public class GetAllOrderQueryHandlerTest
{
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly Mock<ILogger<GetAllOrderQuery.GetAllOrderQueryHandler>> _logger;
    private readonly GetAllOrderQuery.GetAllOrderQueryHandler _handler;
    public GetAllOrderQueryHandlerTest()
    {
        _orderRepository = new Mock<IOrderRepository>();
        _logger = new Mock<ILogger<GetAllOrderQuery.GetAllOrderQueryHandler>>();
        _handler = new GetAllOrderQuery.GetAllOrderQueryHandler(_orderRepository.Object,_logger.Object);
        

    }
    [SetUp]
    public void SetUp()
    {
        _orderRepository.Invocations.Clear();
    }

    [Test]
    public async Task Handle_Should_Return_All_Orders()
    {
       
        var Order = new GetAllOrderQuery();
        var orders = new List<Order>
        {
            new Order { Id = 1, PersonName = "Yılmaz" },
            new Order { Id = 2, PersonName = "Özge" },
            new Order { Id = 3, PersonName = "Furkan" }
        };
        _orderRepository.Setup(p => p.GetOrder()).ReturnsAsync(orders);
        var result=await _handler.Handle(Order, default);
        Assert.NotNull(result);
        Assert.AreEqual(3, result.Count);
    }
} 