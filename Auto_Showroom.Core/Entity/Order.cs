namespace Auto_Showroom.Core.Model;

public class Order
{
     
    public int Id { get; set; }
    public string PersonName { get; set; }
    public List<OrderItem> OrderItems{ get; set; }
    public DateTime OrderDate { get; set; } 
    
    
}