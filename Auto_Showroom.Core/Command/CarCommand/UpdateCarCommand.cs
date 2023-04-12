using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Command;

public class UpdateCarCommand:IRequest<Car>
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Model { get; set; }

   
}

public class UpdateCarCommandHandle : IRequestHandler<UpdateCarCommand,Car>
{
    private readonly ICarRepository _carRepository;
    private readonly ILogger<UpdateCarCommandHandle> _logger;
    public  UpdateCarCommandHandle(ICarRepository carRepository,ILogger<UpdateCarCommandHandle>logger)
    {
        _carRepository = carRepository;
        _logger = logger;
    }
    
    public async Task<Car> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"Called with CarId{request.Id}and car update");
        var car=await _carRepository.GetCarById(request.Id);
        
        car.Price = request.Price;
        car.Model = request.Model;
        
        
         await _carRepository.UpdateCar(car);
         return car;
    }
}