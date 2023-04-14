using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command;

public class CreateCarCommandHandlerTest
{
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<CreateCarHandler>> _logger;
    private readonly CreateCarHandler _handler;
    public CreateCarCommandHandlerTest()
    {
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<CreateCarHandler>>();
        _handler = new CreateCarHandler(_carRepository.Object, _logger.Object);
    }
    [SetUp]
    public void SetUp()
    {
        _carRepository.Invocations.Clear();
    }
    [Test]
    public async Task Handle_ValidRequest_ReturnsCar()
    {
        //given
        var command = new CreateCarCommand
        {
            
            Model = "Tesla",
            Price = 1000
        };
       //when
        await _handler.Handle(command, default);
        //then
         _carRepository.Verify(p => p.AddCar(It.IsAny<Car>()), Times.Once);
        
    }

    
    
}