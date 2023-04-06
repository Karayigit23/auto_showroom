namespace Auto_Showroom.Core.Model;

public class Order
{
    public int PersonId { get; set; }
    public string PersonName { get; set; } 
    public Orderİtem Orderİtem { get; set; }
    
}