using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Query;

public class GetAllCarQueryHandlerTest
{
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<GetAllCarQuery.GetAllCarQueryHandler>> _logger;
    private readonly GetAllCarQuery.GetAllCarQueryHandler _handler;

    public GetAllCarQueryHandlerTest()
    {
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<GetAllCarQuery.GetAllCarQueryHandler>>();
        _handler = new GetAllCarQuery.GetAllCarQueryHandler(_carRepository.Object, _logger.Object);

    }
    [SetUp]
    public void SetUp()
    {
        _carRepository.Invocations.Clear();
    }

    [Test]
    public async Task Handle_Should_ReturnListOfCars()
    {
        //given
        var car = new GetAllCarQuery();
        var listCars = new List<Car>
        {
            new Car { Id = 1, Model = "Ford", Price = 5 },
            new Car { Id = 2, Model = "Nissan", Price = 10 }
        };
        _carRepository.Setup(repo => repo.GetCars()).ReturnsAsync(listCars);
        //when
        var result=await _handler.Handle(car, default);
        //then
        Assert.NotNull(result);
        Assert.AreEqual(listCars.Count,result.Count);
        Assert.AreEqual(listCars[0].Id,result[0].Id);
        Assert.AreEqual(listCars[0].Model, result[0].Model);
        Assert.AreEqual(listCars[0].Price, result[0].Price);
        Assert.AreEqual(listCars[1].Id, result[1].Id);
        Assert.AreEqual(listCars[1].Model, result[1].Model);
        Assert.AreEqual(listCars[1].Price, result[1].Price);
        
        _carRepository.Verify(repo => repo.GetCars(), Times.Once);
        
    }
    
}