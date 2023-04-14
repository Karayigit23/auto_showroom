using System;

namespace Auto_Showroom.Middlewares;

public class BadRequestException: Exception
{ 
    public int StatusCode { get; set; }
    public BadRequestException() : base() { } 
    public BadRequestException(string message) : base(message) { } 
    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }

    public BadRequestException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    public BadRequestException(string message, Exception innerException, int statusCode) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
    
    
}