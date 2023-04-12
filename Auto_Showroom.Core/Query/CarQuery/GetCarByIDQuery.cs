
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;


public class GetCarByIDQuery : IRequest<Car>
{
    public int Id { get; set; }      
}

public class GetCarByIDHandle : IRequestHandler<GetCarByIDQuery, Car>
{
    private readonly ICarRepository _carRepository;
    private readonly ILogger<GetCarByIDHandle> _logger;
    public GetCarByIDHandle(ICarRepository carRepository,ILogger<GetCarByIDHandle> logger)
    {
        _carRepository = carRepository;
        _logger = logger;
    }

    public async Task<Car> Handle(GetCarByIDQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"{request.Id} car came");
        return await _carRepository.GetCarById(request.Id);
    }
}    
       

      

    
  