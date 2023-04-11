namespace Auto_Showroom.Core.Model;

public class Order
{
     
    public int Id { get; set; } //sipariş numarası
    
   
    public string PersonName { get; set; } //Sipariş eden kişinin adı
    public Car Car { get; set; } //sipariş edilen araç 
    
    public List<OrderItem> OrderItems{ get; set; }//sipariş öğeleri
    public DateTime OrderDate { get; set; } // sipariş tarihi 
    
    
}