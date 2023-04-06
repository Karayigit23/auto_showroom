using FluentValidation;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.DeleteCar;

public class DeleteCarValidator:AbstractValidator<DeleteCarCommand>
{
    public DeleteCarValidator()
    {
        RuleFor(p => p.CarId).GreaterThan(0);
    }
}