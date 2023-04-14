using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Auto_Showroom.Core.Command;

public class DeleteCarCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteCarCommandHandle : IRequestHandler<DeleteCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly ILogger<DeleteCarCommandHandle> _logger;
    public DeleteCarCommandHandle(ICarRepository carRepository,ILogger<DeleteCarCommandHandle> logger)
    {
        _carRepository = carRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"Car deleted");
        var car = await _carRepository.GetCarById(request.Id);
        if (car == null)
        {
            throw new Exception();
        }
        await _carRepository.DeleteCar(car);
       return Unit.Value; //mediatR sürümünü düşürdüğüm için hata verdi oyüzden bu değişiklik yapldı (sürümün düşürme sebebim dependencyInjection sürümü mediatr ile uyuşmuyor)
    }
}  