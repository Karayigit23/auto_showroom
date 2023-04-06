using FluentValidation;
namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;

public class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Test.Price).GreaterThan(0);
    }
}