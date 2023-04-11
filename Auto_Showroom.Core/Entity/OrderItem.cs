namespace Auto_Showroom.Core.Model;

public class OrderItem:EntityBase
{
    public int OrderId { get; set; }
    public int CarId { get; set; }
    public int Quantity { get; set; }
}   
    