using FluentValidation;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.GetOrder.Validator;

public class OrderValidator:AbstractValidator<GetOrderByIDQuery>
{
    public OrderValidator()
    {
        RuleFor(p => p.OrderId).GreaterThan(0);
    }
    
}