namespace Auto_Showroom.Core.Model;

public class Order
{
     
    public int OrderId { get; set; } //sipariş numarası
    
    public int CarId { get; set; } //sipariş edilen Aracın Idsi
    public string PersonName { get; set; } //Sipariş eden kişinin adı
    public Car Car { get; set; } //sipariş edilen araç 
    
    public List<OrderItem> OrderItems{ get; set; }//sipariş öğeleri
    public DateTime OrderDate { get; set; } // sipariş tarihi 
    
    
}