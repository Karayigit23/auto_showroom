using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Microsoft.Extensions.Logging;
using Moq;

namespace Auto_Showroom.Test.Core.Query;

public class GetCarByIDQueryHandlerTest
{
    private readonly Mock<ICarRepository> _carRepository;
    private readonly Mock<ILogger<GetCarByIDHandle>> _logger;
    private readonly GetCarByIDHandle _handler;
    public GetCarByIDQueryHandlerTest()
    {
        _carRepository = new Mock<ICarRepository>();
        _logger = new Mock<ILogger<GetCarByIDHandle>>();
        _handler = new GetCarByIDHandle(_carRepository.Object, _logger.Object);
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
        var command = new GetCarByIDQuery()
        {
            Id = 1

        };
        _carRepository.Setup(p => p.GetCarById(command.Id)).ReturnsAsync((Car)null);
        //when//then
        Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, default));
        _carRepository.Verify(p=>p.GetCarById(command.Id),Times.Once);
        
    }
}