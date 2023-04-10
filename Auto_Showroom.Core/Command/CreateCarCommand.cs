
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;


public class CreateCarCommand : IRequest<Car>
{

    public decimal Price { get; set; }
    public string Model { get; set; }
}



public class CreateCarHandler:IRequestHandler<CreateCarCommand,Car>
{
    private readonly ICarRepository _carRepository;
    
    public CreateCarHandler(ICarRepository carRepository )
    {
        _carRepository = carRepository;

    }


   

    public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {



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

