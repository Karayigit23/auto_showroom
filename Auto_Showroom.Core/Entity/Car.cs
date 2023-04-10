using MediatR;

namespace Auto_Showroom.Core.Model;

public class Car:EntityBase, IRequest
{
   
    public decimal Price { get; set; }
    public string Model { get; set; }
    
}