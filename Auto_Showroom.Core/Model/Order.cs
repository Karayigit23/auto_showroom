namespace Auto_Showroom.Core.Model;

public class Order
{
    public int PersonId { get; set; }
    public string PersonName { get; set; } 
    public OrderItem OrderItem { get; set; }
    public DateTime OrderDate { get; set; }
    
}