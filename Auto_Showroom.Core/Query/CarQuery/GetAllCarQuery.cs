using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Command;

public class GetAllCarQuery:IRequest<List<Car>>
{
    
    public class GetAllCarQueryHandler:IRequestHandler<GetAllCarQuery,List<Car>>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<GetAllCarQueryHandler> _logger;

        public GetAllCarQueryHandler(ICarRepository carRepository,ILogger<GetAllCarQueryHandler> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }
        public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(message:"All the cars have came");
            return await _carRepository.GetCars();
        }
    }
}