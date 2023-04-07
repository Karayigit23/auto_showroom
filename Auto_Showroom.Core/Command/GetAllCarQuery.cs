using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command;

public class GetAllCarQuery:IRequest<List<Car>>
{
    
    public class GetAllCarQueryHandler:IRequestHandler<GetAllCarQuery,List<Car>>
    {
        private readonly IRepository _repository;

        public GetAllCarQueryHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetCar();

            return car;
          
           
           
        }
    }
}