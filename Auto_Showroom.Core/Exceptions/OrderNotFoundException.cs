namespace Auto_Showroom.Core.Exceptions;

public class OrderNotFoundException:Exception
{
    public OrderNotFoundException(string message) : base(message)
    {
        
    }
}