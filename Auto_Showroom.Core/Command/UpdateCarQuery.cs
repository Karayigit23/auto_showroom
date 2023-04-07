using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command;

public class UpdateCarQuery:IRequest<Car>
{
    public Car Car { get; set; }

   
}

public class UpdateCarQueryHandle : IRequestHandler<UpdateCarQuery,Car>
{
    private readonly IRepository _repository; 
    public  UpdateCarQueryHandle(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<Car> Handle(UpdateCarQuery request, CancellationToken cancellationToken)
    {
         await _repository.UpdateCar(request.Car);
         return request.Car;
    }
}