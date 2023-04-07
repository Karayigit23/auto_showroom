using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using MediatR;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;


public class CreateCarRequestCommand : IRequest<Car>
{
    
    public decimal Price { get; set; }
    public string Model { get; set; }
}



public class CreateCarHandler:IRequestHandler<CreateCarRequestCommand,Car>
{
    private readonly IRepository _repository;
    public CreateCarHandler(IRepository repository)
    {
        _repository = repository;

    }


   

    public async Task<Car> Handle(CreateCarRequestCommand request, CancellationToken cancellationToken)
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



      await _repository.AddCar(car);
      return car;



    }

    
}

