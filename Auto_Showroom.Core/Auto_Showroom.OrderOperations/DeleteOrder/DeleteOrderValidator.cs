using FluentValidation;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.DeleteOrder;

public class DeleteOrderValidator:AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(p => p.PersonId).GreaterThan(0);
    }
}
