using Auto_Showroom.Core.Interfaces;
using MediatR;


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

    public async Task<Unit> Handle(DeleteCarQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetCarById(request.Id);
        await _carRepository.DeleteCar(car);
       return Unit.Value; //mediatR sürümünü düşürdüğüm için hata verdi oyüzden bu değişiklik yapldı (sürümün düşürme sebebim dependencyInjection sürümü mediatr ile uyuşmuyor)
    }
}  