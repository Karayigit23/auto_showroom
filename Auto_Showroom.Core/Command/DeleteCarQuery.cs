using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Auto_Showroom.Core.Command;

public class DeleteCarQuery:IRequest
{
    public int Id { get; set; }
}
public class DeleteCarQueryHandle : IRequestHandler<DeleteCarQuery>
{
    private readonly ICarRepository _carRepository;
    public DeleteCarQueryHandle(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task Handle(DeleteCarQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetCarById(request.Id);
        await _carRepository.DeleteCar(car);
       
    }
}  