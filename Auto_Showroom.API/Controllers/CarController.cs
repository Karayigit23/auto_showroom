using System.Collections.Generic;
using System.Threading.Tasks;
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

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    ///<summary>
    ///Get All Cars
    /// </summary>
    /// <returns>List of Cars</returns>
    [HttpGet]
    public async Task<List<Car>> Get()
    {
       return await _mediator.Send(new GetAllCarQuery());
    }
    
    ///<summary>
    ///Get Car By Id
    ///</summary>
    /// <param name="CarId">The ID of the car to retrieve</param>
    /// <returns>The retrieved car</returns>
    [HttpGet("{CarId}")]
    public async Task<Car> GetById(int CarId)
    {
        
        return await _mediator.Send( request: new GetCarByIDQuery{Id = CarId});
    }
    
    ///<summary>
    ///Create a car
    /// </summary>
    /// <param name="newCar">The data for the new car to be created</param>
    /// <returns></returns>
    [HttpPost]
    public async Task Post ([FromBody] CreateCarCommand newCar)
    {
        await _mediator.Send(newCar);

    }
    ///<summary>
    ///Update the car
    /// </summary>
    /// <param name="CarId">The ID of the car to be update</param>
    /// <param name="updateCar">The updated car object</param>
    /// <returns></returns>
    [HttpPut("{CarId}")]
    public async Task Put(int CarId, [FromBody]  UpdateCarCommand updateCar)
    {
        updateCar.Id = CarId;
        await _mediator.Send(updateCar);
    }
    ///<summary>
    ///Delete the car 
    /// </summary>
    /// <param name="CarId">The ID of the car to be deleted </param>
    /// <returns></returns>
    [HttpDelete("{CarId}")]
    public async Task Delete(int CarId)
    {
        await _mediator.Send( new DeleteCarCommand{Id = CarId});
    }
    
}


