using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;
using FluentValidation;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.PostOrder;

public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.Test.PersonName).NotEmpty().MinimumLength(2);
        RuleFor(command => command.Test.OrderDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        
        
    }
}