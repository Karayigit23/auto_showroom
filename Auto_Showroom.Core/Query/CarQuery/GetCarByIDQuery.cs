
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;


namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;


public class GetCarByIDQuery : IRequest<Car>
{
    public int Id { get; set; }      
}

public class GetCarByIDHandle : IRequestHandler<GetCarByIDQuery, Car>
{
    private readonly ICarRepository _carRepository;
    public GetCarByIDHandle(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car> Handle(GetCarByIDQuery request, CancellationToken cancellationToken)
    {
        return await _carRepository.GetCarById(request.Id);
    }
}    
       

      

    
  