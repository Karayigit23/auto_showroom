using FluentValidation;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.PutOrder;

public class UpdateOrderValidator:AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(command => command.Test.PersonName).NotEmpty().MinimumLength(2);
        RuleFor(command => command.Test.OrderDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        
    }
}

    
