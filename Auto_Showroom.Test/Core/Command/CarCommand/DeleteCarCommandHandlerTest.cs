using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Command;

public class DeleteCarCommandHandlerTest
{
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<DeleteCarCommandHandle>> _logger;
    private readonly DeleteCarCommandHandle _handler;
    public DeleteCarCommandHandlerTest()
    {
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<DeleteCarCommandHandle>>();
        _handler = new DeleteCarCommandHandle(_carRepository.Object, _logger.Object);
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
        var command = new DeleteCarCommand
        {
            Id = 1,
           
        };
        _carRepository.Setup(p => p.GetCarById(command.Id)).ReturnsAsync((Car)null);


        //when  //then
        Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, default));
        _carRepository.Verify(p=>p.GetCarById(command.Id),Times.Once);
        _carRepository.Verify(p=>p.DeleteCar(It.IsAny<Car>()),Times.Never);
    }
    //eksik düzelt
    [Test]
    public async Task handle_when_car_exist_then_delete_car()
    {
        //given
        var command = new DeleteCarCommand
        {
            Id = 1,
            
        };

       
        _carRepository.Setup(p => p.GetCarById(command.Id)).ReturnsAsync(new Car{Id=command.Id});


        //when
        await _handler.Handle(command, default);
        
        
        //then

  
       
        
        _carRepository.Verify(p=>p.GetCarById(command.Id),Times.Once);
        _carRepository.Verify(p=>p.DeleteCar(It.IsAny<Car>()),Times.Once);
    }
}