using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Auto_Showroom.Controllers;
[Route("carcontroller")]
public class CarController:ControllerBase
{
   
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
      
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Car>> Get()
    {
        
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
    public async Task Put(int CarId, [FromBody]  UpdateCarQuery updateCar)
    {

        await _mediator.Send(updateCar);
    }

    [HttpDelete("{CarId}")]
    public async Task Delete(int CarId)
    {
       
       await _mediator.Send( new DeleteCarQuery{Id = CarId});
    }
    
}


