using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Infrastructure;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.DeleteCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar.Validator;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PutCar;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Showroom.Controllers;
[Route("carcontroller")]
public class CarController:ControllerBase
{
    private readonly AppDbContext _appDb;

    public CarController(AppDbContext db)
    {
        _appDb = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        GetCarQuery query = new GetCarQuery(_appDb);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{CarId}")]
    public IActionResult GetById(int CarId)
    {
        CarViewTest result;
        try
        {
            GetCarByIDQuery query = new GetCarByIDQuery(_appDb);
            query.CarId = CarId;
            CarValidator validator = new CarValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateCarTest newCar)
    {
        CreateCarCommand command = new CreateCarCommand(_appDb);
        try
        {
            command.Test = newCar;
            CreateCarCommandValidator validator = new CreateCarCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
           
 

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);


        }

        return Ok();
    }

    [HttpPut("{CarId}")]
    public IActionResult Put(int CarId, [FromBody] UpdateCarTest updateCar)
    {
        try
        {
            UpdateCarCommand update = new UpdateCarCommand(_appDb);
            update.CarId = CarId;
            update.Test = updateCar;
            UpdateCarValidator validator = new UpdateCarValidator();
            validator.ValidateAndThrow(update);
            update.Handle();
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            
        }

        return Ok();
    }

    [HttpDelete("{CarId}")]
    public IActionResult Delete(int CarId)
    {
        DeleteCarCommand delete= new DeleteCarCommand(_appDb);
        delete.CarId = CarId;
        DeleteCarValidator validator = new DeleteCarValidator();
        validator.ValidateAndThrow(delete);
        delete.Handle();
        return Ok();
    }
    
}