namespace Auto_Showroom.Core.Exceptions;

public class CarNotFoundException : Exception
{
    public CarNotFoundException(string message): base(message)
    {
        
    }
}
