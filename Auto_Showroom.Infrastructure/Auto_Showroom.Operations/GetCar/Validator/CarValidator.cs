using FluentValidation;
namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar.Validator;

public class CarValidator:AbstractValidator<GetCarByIDQuery>
{
    public CarValidator()
    {
        RuleFor(p => p.CarId).GreaterThan(0);
    }
}