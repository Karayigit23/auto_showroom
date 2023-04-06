using FluentValidation;
namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PutCar;

public class UpdateCarValidator:AbstractValidator<UpdateCarCommand>
{
    public UpdateCarValidator()
    {
        RuleFor(p => p.Test.Price).GreaterThan(0);
        
    }
}