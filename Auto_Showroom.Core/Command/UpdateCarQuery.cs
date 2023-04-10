using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command;

public class UpdateCarQuery:IRequest<Car>
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Model { get; set; }

   
}

public class UpdateCarQueryHandle : IRequestHandler<UpdateCarQuery,Car>
{
    private readonly ICarRepository _carRepository; 
    public  UpdateCarQueryHandle(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<Car> Handle(UpdateCarQuery request, CancellationToken cancellationToken)
    {
        var car=await _carRepository.GetCarById(request.Id);
        
        car.Price = request.Price;
        car.Model = request.Model;
        
        
         await _carRepository.UpdateCar(car);
         return car;
    }
}