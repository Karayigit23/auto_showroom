using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command;

public class GetAllCarQuery:IRequest<List<Car>>
{
    
    public class GetAllCarQueryHandler:IRequestHandler<GetAllCarQuery,List<Car>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.GetCars();
        }
    }
}