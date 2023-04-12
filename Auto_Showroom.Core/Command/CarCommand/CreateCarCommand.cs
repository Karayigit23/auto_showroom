
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;


public class CreateCarCommand : IRequest<Car>
{

    public decimal Price { get; set; }
    public string Model { get; set; }
}



public class CreateCarHandler:IRequestHandler<CreateCarCommand,Car>
{
    private readonly ICarRepository _carRepository;
    private readonly ILogger<CreateCarHandler> _logger;

    public CreateCarHandler(ICarRepository carRepository,ILogger<CreateCarHandler>logger)
    {
        _carRepository = carRepository;
        _logger = logger;

    }
    
    public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:"Car created");
        var car = new Car();
      try
      {
          car.Model = request.Model;
          car.Price = request.Price;
          
      }
      catch (Exception e)
      {
          throw new InvalidOperationException("this car is registered");
      }



      await _carRepository.AddCar(car);
      return car;



    }

    
}

