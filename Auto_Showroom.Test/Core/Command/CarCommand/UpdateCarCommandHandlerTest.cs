using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command;

public class UpdateCarCommandHandlerTest
{
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<UpdateCarCommandHandler>> _logger;
    private readonly UpdateCarCommandHandler _handler;
    
    public UpdateCarCommandHandlerTest()
    {
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<UpdateCarCommandHandler>>();
        _handler = new UpdateCarCommandHandler(_carRepository.Object, _logger.Object);
    }

    [SetUp]
    public void SetUp()
    {
        _carRepository.Invocations.Clear();
    }


    [Test]
    public async Task handle_when_car_is_not_exist_then_throw_exception()
    {
        //given
        var command = new UpdateCarCommand
        {
            Id = 1,
            Model = "Ford",
            Price = 3434
        };
        _carRepository.Setup(p => p.GetCarById(command.Id)).ReturnsAsync((Car)null);


        //when  //then
        Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, default));
        _carRepository.Verify(p=>p.GetCarById(command.Id),Times.Once);
        _carRepository.Verify(p=>p.UpdateCar(It.IsAny<Car>()),Times.Never);
    }
    
    [Test]
    public async Task handle_when_car_exist_then_update_car()
    {
        //given
        var command = new UpdateCarCommand
        {
            Id = 1,
            Model = "Ford",
            Price = 4
        };

        var car = new Car
        {
            Id = 1,
            Model = "Nissan",
            Price = 20
        };
        _carRepository.Setup(p => p.GetCarById(command.Id)).ReturnsAsync(car);


        //when
        await _handler.Handle(command, default);
        
        
        //then
        car.Model.Should().Be(command.Model);
        car.Price.Should().Be(command.Price);
        
        _carRepository.Verify(p=>p.GetCarById(command.Id),Times.Once);
        _carRepository.Verify(p=>p.UpdateCar(It.IsAny<Car>()),Times.Once);
    }


}