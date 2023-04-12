using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Auto_Showroom.Controllers;
[ApiController]
[Route("cars")]
public class CarController:ControllerBase
{
   
    private readonly IMediator _mediator;
    private readonly ILogger<CarController> _logger;

    public CarController(IMediator mediator,ILogger<CarController> logger)
    {
      
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Car>> Get()
    {
        _logger.LogInformation(message:"All the cars have arrived");
       return await _mediator.Send(new GetAllCarQuery());
        
    }

    [HttpGet("{CarId}")]
    public async Task<Car> GetById(int CarId)
    {
        
        return await _mediator.Send( request: new GetCarByIDQuery{Id = CarId});
    }

    [HttpPost]
    public async Task Post ([FromBody] CreateCarCommand newCar)
    {
        await _mediator.Send(newCar);

    }

    [HttpPut("{CarId}")]
    public async Task Put(int CarId, [FromBody]  UpdateCarCommand updateCar)
    {
        updateCar.Id = CarId;
        await _mediator.Send(updateCar);
    }

    [HttpDelete("{CarId}")]
    public async Task Delete(int CarId)
    {
       
       await _mediator.Send( new DeleteCarCommand{Id = CarId});
    }
    
}


